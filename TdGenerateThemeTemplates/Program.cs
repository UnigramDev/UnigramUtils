using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TdGenerateThemeTemplates
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = XDocument.Load(args[0]);
            ToDictionary(document);
            ToString(document);
        }

        static void ToDictionary(XDocument document)
        {
            var xmlns = XNamespace.Get("http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            var x = XNamespace.Get("http://schemas.microsoft.com/winfx/2006/xaml");

            var themes = document.Descendants(xmlns + "ResourceDictionary.ThemeDictionaries").FirstOrDefault();
            var builder = new StringBuilder();

            foreach (var resources in themes.Descendants(xmlns + "ResourceDictionary"))
            {
                builder.AppendLine(string.Format("\t\tprivate readonly Dictionary<string, object> _default{0} = new Dictionary<string, object>", resources.Attribute(x + "Key").Value));
                builder.AppendLine("\t\t{");

                foreach (var item in resources.Descendants())
                {
                    string key = null;
                    string color = null;

                    if (item.Name == (xmlns + "SolidColorBrush"))
                    {
                        key = item.Attribute(x + "Key").Value;
                        color = item.Attribute("Color").Value;

                        if (color.StartsWith('{'))
                        {
                            color = color.Trim('{', '}').Split(' ')[1];
                        }
                    }
                    else if (item.Name == (xmlns + "StaticResource"))
                    {
                        key = item.Attribute(x + "Key").Value;
                        color = item.Attribute("ResourceKey").Value;

                        if (string.Equals(color, "SystemControlTransparentBrush"))
                        {
                            continue;
                        }
                    }
                    else if (item.Name == (xmlns + "Color"))
                    {
                        key = item.Attribute(x + "Key").Value;
                        color = item.Value;
                    }

                    if (key != null)
                    {
                        if (color.StartsWith("#"))
                        {
                            color = color.Substring(1);

                            var a = color.Length == 8 ? color.Substring(0, 2) : "FF";
                            var r = color.Length == 8 ? color.Substring(2, 2) : color.Substring(0, 2);
                            var g = color.Length == 8 ? color.Substring(4, 2) : color.Substring(2, 2);
                            var b = color.Length == 8 ? color.Substring(6, 2) : color.Substring(4, 2);

                            //byte a = (byte)((hexValue & 0xff000000) >> 24);
                            //byte r = (byte)((hexValue & 0x00ff0000) >> 16);
                            //byte g = (byte)((hexValue & 0x0000ff00) >> 8);
                            //byte b = (byte)(hexValue & 0x000000ff);

                            builder.AppendLine(string.Format("\t\t\t{{ \"{0}\", Color.FromArgb(0x{1}, 0x{2}, 0x{3}, 0x{4}) }},", key, a, r, g, b));
                        }
                        else
                        {
                            builder.AppendLine(string.Format("\t\t\t{{ \"{0}\", \"{1}\" }},", key, color));
                        }
                    }
                    else
                    {
                        var a = "b";
                    }
                }

                builder.AppendLine("\t\t};\r\n");
            }
        }

        static void ToString(XDocument document)
        {
            var xmlns = XNamespace.Get("http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            var x = XNamespace.Get("http://schemas.microsoft.com/winfx/2006/xaml");

            var dark = document.Descendants(xmlns + "ResourceDictionary").FirstOrDefault(y => y.Attribute(x + "Key") != null && string.Equals(y.Attribute(x + "Key").Value, "Dark"));
            var resources = dark.Descendants(xmlns + "StaticResource");

            var builder = new StringBuilder();
            var borders = new StringBuilder();
            var control = new StringBuilder();
            borders.Append("<local:ResourcesMapper");

            foreach (var item in resources)
            {
                var key = item.Attribute(x + "Key").Value;
                var color = item.Attribute("ResourceKey").Value;

                if (string.Equals(color, "SystemControlTransparentBrush"))
                {
                    continue;
                }

                builder.AppendLine(string.Format("\t<DataTemplate x:Key=\"{0}Template\">", key));
                builder.AppendLine(string.Format("\t\t<Ellipse Width=\"24\" Height=\"24\" Fill=\"{{ThemeResource {0}}}\" Stroke=\"White\" StrokeThickness=\"1\"/>", key));
                builder.AppendLine(string.Format("\t</DataTemplate>\r\n"));

                borders.Append(string.Format("\r\n            {0}=\"{{ThemeResource {0}}}\" ", key));

                control.AppendLine(string.Format(@"        public object {0}
        {{
            get {{ return (object)GetValue({0}Property); }}
            set {{ SetValue({0}Property, value); }}
        }}

        public static readonly DependencyProperty {0}Property =
            DependencyProperty.Register(""{0}"", typeof(object), typeof(ResourcesMapper), new PropertyMetadata(null));", key));
            }

            borders.Append(" />");

            var text = borders.ToString();
            var text2 = control.ToString();
        }
    }
}
