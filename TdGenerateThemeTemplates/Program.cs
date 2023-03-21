using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
            var fileName = args[0];
            var input = fileName.Replace(".xaml", ".taml");

            var document = XDocument.Load(input);
            ToMapping(document);
            ToDefault(document, fileName);
            ToDictionary(document);

            //document.Save(fileName);
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

        // Used to generate theme lookups
        static void ToDefault(XDocument document, string fileName)
        {
            var xmlns = XNamespace.Get("http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            var x = XNamespace.Get("http://schemas.microsoft.com/winfx/2006/xaml");
            var media = XNamespace.Get("using:Microsoft.UI.Xaml.Media");

            var themes = document.Descendants(xmlns + "ResourceDictionary.ThemeDictionaries").FirstOrDefault();
            var builder = new StringBuilder();

            var input = fileName.Replace(".xaml", ".taml");
            var text = File.ReadAllText(input);

            var opacities = new Dictionary<string, Dictionary<string, string>>();
            opacities["Light"] = new();
            opacities["Dark"] = new();
            opacities["Light"]["AcrylicBackgroundFillColorDefaultBrush"] = "0.85";
            opacities["Light"]["AcrylicInAppFillColorDefaultBrush"] = "0.85";
            opacities["Light"]["AcrylicBackgroundFillColorDefaultInverseBrush"] = "0.96";
            opacities["Light"]["AcrylicInAppFillColorDefaultInverseBrush"] = "0.96";
            opacities["Light"]["AcrylicBackgroundFillColorBaseBrush"] = "0.9";
            opacities["Light"]["AcrylicInAppFillColorBaseBrush"] = "0.9";
            opacities["Light"]["AccentAcrylicBackgroundFillColorDefaultBrush"] = "0.9";
            opacities["Light"]["AccentAcrylicInAppFillColorDefaultBrush"] = "0.9";
            opacities["Light"]["AccentAcrylicBackgroundFillColorBaseBrush"] = "0.9";
            opacities["Light"]["AccentAcrylicInAppFillColorBaseBrush"] = "0.9";
            opacities["Dark"]["AcrylicBackgroundFillColorDefaultBrush"] = "0.96";
            opacities["Dark"]["AcrylicInAppFillColorDefaultBrush"] = "0.96";
            opacities["Dark"]["AcrylicBackgroundFillColorDefaultInverseBrush"] = "0.85";
            opacities["Dark"]["AcrylicInAppFillColorDefaultInverseBrush"] = "0.85";
            opacities["Dark"]["AcrylicBackgroundFillColorBaseBrush"] = "0.96";
            opacities["Dark"]["AcrylicInAppFillColorBaseBrush"] = "0.96";
            opacities["Dark"]["AccentAcrylicBackgroundFillColorDefaultBrush"] = "0.8";
            opacities["Dark"]["AccentAcrylicInAppFillColorDefaultBrush"] = "0.8";
            opacities["Dark"]["AccentAcrylicBackgroundFillColorBaseBrush"] = "0.8";
            opacities["Dark"]["AccentAcrylicInAppFillColorBaseBrush"] = "0.8";

            foreach (var resources in themes.Descendants(xmlns + "ResourceDictionary").Reverse())
            {
                builder.AppendLine(string.Format("\t\tprivate static readonly Dictionary<string, object> _default{0} = new Dictionary<string, object>", resources.Attribute(x + "Key").Value));
                builder.AppendLine("\t\t{");

                var mapping = new Dictionary<string, string>();
                var colors = new Dictionary<string, string>();

                var accents = new Dictionary<string, string>();

                var brushToColor = new Dictionary<string, string>();
                var staticReplacements = new Dictionary<string, string>();

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

                bool GetColor(string value, out string color, out string key)
                {
                    var themeMatch = themeRegex.Match(value);
                    var staticMatch = staticRegex.Match(value);

                    if (staticMatch.Success && colors.TryGetValue(staticMatch.Groups[1].Value, out string staticValue))
                    {
                        key = staticMatch.Groups[1].Value;
                        color = staticValue;
                        return true;
                    }
                    if (themeMatch.Success && colors.TryGetValue(themeMatch.Groups[1].Value, out string themeValue))
                    {
                        key = themeMatch.Groups[1].Value;
                        color = themeValue;
                        return true;
                    }
                    else if (value.StartsWith("#"))
                    {
                        key = value;
                        color = value;
                        return true;
                    }

                    key = null;
                    color = null;
                    return false;
                }

                foreach (var item in resources.Descendants())
                {
                    if (item.Name == (xmlns + "SolidColorBrush"))
                    {
                        var key = item.Attribute(x + "Key").Value;
                        var color = item.Attribute("Color").Value;

                        var themeMatch = themeRegex.Match(color);
                        var staticMatch = staticRegex.Match(color);

                        if (GetColor(color, out string value, out string reference))
                        {
                            mapping[key] = value;
                            brushToColor[key] = string.Format("<SolidColorBrush x:Key=\"{{0}}\" Color=\"{0}\" />", reference.StartsWith('#') ? reference : $"{{{{StaticResource {reference}}}}}");
                        }
                    }
                    else if (item.Name == (media + "AcrylicBrush"))
                    {
                        var key = item.Attribute(x + "Key").Value;
                        // TintColor="#2C2C2C" TintOpacity="0.15" FallbackColor="#2C2C2C" BackgroundSource="HostBackdrop" />
                        var tintColor = item.Attribute("TintColor").Value;
                        var tintOpacity = item.Attribute("TintOpacity").Value;
                        var fallbackColor = item.Attribute("FallbackColor").Value;

                        var themeMatch = themeRegex.Match(tintColor);
                        var staticMatch = staticRegex.Match(tintColor);

                        if (GetColor(tintColor, out string tintValue, out string tintResource)
                            && GetColor(fallbackColor, out string fallbackValue, out string fallbackResource))
                        {
                            // Mixed scenario isn't supported but let's pretend it is

                            string generic;
                            if (tintValue.StartsWith('#'))
                            {
                                tintValue = GetHex(tintValue);
                                generic = ".Color";
                            }
                            else
                            {
                                generic = ".Shade";
                            }

                            if (fallbackValue.StartsWith('#'))
                            {
                                fallbackValue = GetHex(fallbackValue);
                            }

                            if (opacities[resources.Attribute(x + "Key").Value].TryGetValue(key, out string opacity))
                            {
                                mapping[key] = string.Format("Acrylic{4}({0}, {1}, {2}, {3})", tintValue, fallbackValue, tintOpacity, opacity, generic);
                            }
                            else
                            {
                                mapping[key] = string.Format("Acrylic{3}({0}, {1}, {2})", tintValue, fallbackValue, tintOpacity, generic);
                            }

                            brushToColor[key] = string.Format("<media:AcrylicBrush x:Key=\"{{0}}\" TintColor=\"{0}\" TintOpacity=\"{1}\" FallbackColor=\"{2}\" />",
                                tintResource.StartsWith('#') ? tintResource : $"{{{{StaticResource {tintResource}}}}}",
                                tintOpacity,
                                fallbackResource.StartsWith('#') ? fallbackResource : $"{{{{StaticResource {fallbackResource}}}}}");
                        }
                    }
                }

                foreach (var item in resources.Descendants())
                {
                    if (item.Name == (xmlns + "StaticResource"))
                    {
                        var key = item.Attribute(x + "Key").Value;
                        var resource = item.Attribute("ResourceKey").Value;

                        if (mapping.TryGetValue(resource, out string value))
                        {
                            mapping[key] = value;

                            if (brushToColor.TryGetValue(resource, out string color))
                            {
                                staticReplacements[key] = color;
                            }
                            else
                            {
                                staticReplacements[key] = value;
                            }
                        }
                        //else if (colors.TryGetValue(resource, out string color))
                        //{
                        //    // Odd, but a thing
                        //    mapping[key] = color;
                        //    staticReplacements[key] = string.Format("<SolidColorBrush x:Key=\"{{0}}\" Color=\"{{{{StaticResource {0}}}}}\" />", resource);
                        //}
                    }
                }

                foreach (var item in mapping)
                {
                    if (item.Value.StartsWith('#'))
                    {
                        var color = item.Value.TrimStart('#');
                        var a = "FF";
                        string r, g, b;

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

                foreach (var replacement in staticReplacements)
                {
                    continue;

                    var regex = new Regex($"<StaticResource x:Key=\"{replacement.Key}\" ResourceKey=\"(.*?)\" />");

                    if (replacement.Value.StartsWith('#'))
                    {
                        text = regex.Replace(text, $"<SolidColorBrush x:Key=\"{replacement.Key}\" Color=\"{replacement.Value}\" />", 1);
                    }
                    else
                    {
                        text = regex.Replace(text, string.Format(replacement.Value, replacement.Key), 1);
                    }
                }

                foreach (var replacement in mapping.Keys.Union(staticReplacements.Keys))
                {
                    //continue;

                    var index = text.IndexOf($"x:Key=\"{replacement}\"");

                    while (index > -1)
                    {
                        var prev = text.LastIndexOf("\r\n", index);
                        var next = text.IndexOf("\r\n", index);

                        text = text.Remove(prev, next - prev);
                        index = text.IndexOf($"x:Key\"{replacement}\"");
                    }
                }
            }

            File.WriteAllText(fileName, text);

            var smth = builder.ToString();
        }

        static string GetHex(string value)
        {
            var color = value.TrimStart('#');
            var a = "FF";
            string r, g, b;

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

            return string.Format("Color.FromArgb(0x{0}, 0x{1}, 0x{2}, 0x{3})", a, r, g, b);

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
    }
}
