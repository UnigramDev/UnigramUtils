using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace TdGenerateThemeTemplates
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = XDocument.Load(args[0]);
            ToMapping(document);
            ToDefault(document);
            ToDictionary(document);
            ToString(document);
        }

        static void UpdateFromWinUI(XDocument document)
        {
            var xmlns = XNamespace.Get("http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            var x = XNamespace.Get("http://schemas.microsoft.com/winfx/2006/xaml");

            var styles = Directory.GetFiles("C:\\Source\\microsoft-ui-xaml\\dev", "*.xaml", SearchOption.AllDirectories);

            var dict = new Dictionary<string, Dictionary<string, XElement>>();

            foreach (var style in styles)
            {
                var name = Path.GetFileNameWithoutExtension(style);
                if ((name.EndsWith("_themeresources") || name.EndsWith("_themeresources_v2.5")) && !name.Contains("_rs") && !name.Contains("_19"))
                {
                    //Debug.WriteLine(name);

                    var source = XDocument.Load(style);
                    var themes2 = source.Descendants(xmlns + "ResourceDictionary.ThemeDictionaries").FirstOrDefault();

                    if (themes2 == null)
                    {
                        Debug.WriteLine(name + ": themes not found");
                        continue;
                    }

                    foreach (var resources in themes2.Descendants(xmlns + "ResourceDictionary").Reverse())
                    {
                        var key = resources.Attribute(x + "Key").Value;
                        if (key == "HighContrast")
                        {
                            continue;
                        }
                        else if (key == "Default")
                        {
                            key = "Dark";
                        }

                        dict.TryGetValue(key, out Dictionary<string, XElement> values);
                        values ??= dict[key] = new Dictionary<string, XElement>();

                        foreach (var item in resources.Descendants())
                        {
                            var inner = item.Attribute(x + "Key");
                            if (inner != null)
                            {
                                values[inner.Value] = item;
                            }
                        }
                    }
                }
            }

            var themes = document.Descendants(xmlns + "ResourceDictionary.ThemeDictionaries").FirstOrDefault();

            foreach (var resources in themes.Descendants(xmlns + "ResourceDictionary").Reverse())
            {
                var key = resources.Attribute(x + "Key").Value;

                dict.TryGetValue(key, out Dictionary<string, XElement> values);

                foreach (var item in resources.Descendants())
                {
                    var inner = item.Attribute(x + "Key");
                    if (inner != null && values.TryGetValue(inner.Value, out XElement source))
                    {
                        item.ReplaceAttributes(source.Attributes());
                    }
                }
            }

            document.Save("test.xaml");
        }

        static void ToMapping(XDocument document)
        {
            var xmlns = XNamespace.Get("http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            var x = XNamespace.Get("http://schemas.microsoft.com/winfx/2006/xaml");

            var themes = document.Descendants(xmlns + "ResourceDictionary.ThemeDictionaries").FirstOrDefault();
            var builder = new StringBuilder();

            foreach (var resources in themes.Descendants(xmlns + "ResourceDictionary").Reverse())
            {
                builder.AppendLine(string.Format("\t\tprivate static readonly Dictionary<string, string[]> _mapping{0} = new Dictionary<string, string[]>", resources.Attribute(x + "Key").Value));
                builder.AppendLine("\t\t{");

                var mapping = new Dictionary<string, List<string>>();

                foreach (var item in resources.Descendants())
                {
                    if (item.Name == (xmlns + "StaticResource"))
                    {
                        var key = item.Attribute(x + "Key").Value;
                        var color = item.Attribute("ResourceKey").Value;

                        if (string.Equals(color, "SystemControlTransparentBrush") /*|| !color.StartsWith("System")*/)
                        {
                            continue;
                        }

                        mapping.TryGetValue(color, out List<string> values);
                        values ??= mapping[color] = new List<string>();
                        values.Add(key);
                    }
                    else if (item.Name == (xmlns + "SolidColorBrush"))
                    {
                        var key = item.Attribute(x + "Key").Value;

                        mapping.TryGetValue(key, out List<string> values);
                        values ??= mapping[key] = new List<string>();
                    }
                }

                foreach (var item in mapping)
                {
                    if (item.Value.Count > 0)
                    {
                        builder.AppendLine(string.Format("\t\t\t{{ \"{0}\", new[] {{ {1} }} }},", item.Key, string.Join(", ", item.Value.Select(x => $"\"{x}\""))));
                    }
                    else
                    {
                        builder.AppendLine(string.Format("\t\t\t{{ \"{0}\", new string[0] }},", item.Key, string.Join(", ", item.Value.Select(x => $"\"{x}\""))));
                    }
                }

                builder.AppendLine("\t\t};\r\n");
            }

            var smth = builder.ToString();
        }

        static void ToDefault(XDocument document)
        {
            var xmlns = XNamespace.Get("http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            var x = XNamespace.Get("http://schemas.microsoft.com/winfx/2006/xaml");

            var themes = document.Descendants(xmlns + "ResourceDictionary.ThemeDictionaries").FirstOrDefault();
            var builder = new StringBuilder();

            foreach (var resources in themes.Descendants(xmlns + "ResourceDictionary").Reverse())
            {
                builder.AppendLine(string.Format("\t\tprivate static readonly Dictionary<string, object> _default{0} = new Dictionary<string, object>", resources.Attribute(x + "Key").Value));
                builder.AppendLine("\t\t{");

                var mapping = new Dictionary<string, string>();
                var colors = new Dictionary<string, string>();

                var accents = new Dictionary<string, string>();

                var themeRegex = new Regex("{ThemeResource (.*?)}");
                var staticRegex = new Regex("{StaticResource (.*?)}");

                foreach (var item in resources.Descendants())
                {
                    if (item.Name == (xmlns + "Color"))
                    {
                        var key = item.Attribute(x + "Key").Value;
                        var color = item.Value;

                        colors[key] = color;
                    }
                }

                colors["SystemAccentColor"] = "AccentShade.Default";
                colors["SystemAccentColorLight1"] = "AccentShade.Light1";
                colors["SystemAccentColorLight2"] = "AccentShade.Light2";
                colors["SystemAccentColorLight3"] = "AccentShade.Light3";
                colors["SystemAccentColorDark1"] = "AccentShade.Dark1";
                colors["SystemAccentColorDark2"] = "AccentShade.Dark2";
                colors["SystemAccentColorDark3"] = "AccentShade.Dark3";

                foreach (var item in resources.Descendants())
                {
                    if (item.Name == (xmlns + "SolidColorBrush"))
                    {
                        var key = item.Attribute(x + "Key").Value;
                        var color = item.Attribute("Color").Value;

                        var themeMatch = themeRegex.Match(color);
                        var staticMatch = staticRegex.Match(color);

                        if (staticMatch.Success && colors.TryGetValue(staticMatch.Groups[1].Value, out string staticValue))
                        {
                            mapping[key] = staticValue;
                        }
                        if (themeMatch.Success && colors.TryGetValue(themeMatch.Groups[1].Value, out string themeValue))
                        {
                            mapping[key] = themeMatch.Groups[1].Value switch
                            {
                                "SystemAccentColor" => "AccentShade.Default",
                                "SystemAccentColorLight1" => "AccentShade.Light1",
                                "SystemAccentColorLight2" => "AccentShade.Light2",
                                "SystemAccentColorLight3" => "AccentShade.Light3",
                                "SystemAccentColorDark1" => "AccentShade.Dark1",
                                "SystemAccentColorDark2" => "AccentShade.Dark2",
                                "SystemAccentColorDark3" => "AccentShade.Dark3",
                            };
                        }
                        else if (color.StartsWith("#"))
                        {
                            mapping[key] = color;
                        }
                    }
                }

                foreach (var item in mapping)
                {
                    if (item.Value.StartsWith('#'))
                    {
                        var color = item.Value.TrimStart('#');
                        var a = "FF";
                        var r = "00";
                        var g = "00";
                        var b = "00";

                        if (color.Length > 6)
                        {
                            a = color.Substring(0, 2);
                            r = color.Substring(2, 2);
                            g = color.Substring(4, 2);
                            b = color.Substring(6, 2);
                        }
                        else
                        {
                            r = color.Substring(0, 2);
                            g = color.Substring(2, 2);
                            b = color.Substring(4, 2);
                        }

                        builder.AppendLine(string.Format("\t\t\t{{ \"{0}\", Color.FromArgb(0x{1}, 0x{2}, 0x{3}, 0x{4}) }},", item.Key, a, r, g, b));
                    }
                    else
                    {
                        builder.AppendLine(string.Format("\t\t\t{{ \"{0}\", {1} }},", item.Key, item.Value));
                    }
                }

                builder.AppendLine("\t\t};\r\n");
            }

            var smth = builder.ToString();
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
