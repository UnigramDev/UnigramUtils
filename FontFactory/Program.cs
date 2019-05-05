using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace FontFactory
{
    class Program
    {
        static Dictionary<string, string> _original = new Dictionary<string, string>();

        static string GetName(string name)
        {
            switch (name)
            {
                case "spade":
                    name = "u2660";
                    break;
                case "club":
                    name = "u2663";
                    break;
                case "heart":
                    name = "u2665";
                    break;
                case "diamond":
                    name = "u2666";
                    break;
                case "arrowboth":
                    name = "u2194";
                    break;
                case "arrowupdn":
                    name = "u2195";
                    break;
                case "numbersign":
                    name = "u0023";
                    break;
                case "asterisk":
                    name = "u002A";
                    break;
                case "zero":
                    name = "u0030";
                    break;
                case "one":
                    name = "u0031";
                    break;
                case "two":
                    name = "u0032";
                    break;
                case "three":
                    name = "u0033";
                    break;
                case "four":
                    name = "u0034";
                    break;
                case "five":
                    name = "u0035";
                    break;
                case "six":
                    name = "u0036";
                    break;
                case "seven":
                    name = "u0037";
                    break;
                case "eight":
                    name = "u0038";
                    break;
                case "nine":
                    name = "u0039";
                    break;
                case "registered":
                    name = "u00AE";
                    break;
                case "copyright":
                    name = "u00A9";
                    break;
                case "trademark":
                    name = "u2122";
                    break;
                case "exclamdbl":
                    name = "u203C";
                    break;
                case "smileface":
                    name = "u263A";
                    break;

                case "H18543":
                    name = "u25AA";
                    break;
                case "H18551":
                    name = "u25AB";
                    break;
            }

            return name.Replace("uni", "u");
        }

        static void Main(string[] args)
        {
            ProcessEmojiOne(new[] { @"C:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\blobmoji.ttx", @"C:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\segoeui.ttx" });
        }

        static void ProcessEmojiOne(string[] args)
        {
            var document = XDocument.Load(args[0]);
            ProcessBase(args[1], document.Root);

            document.Save(Path.GetFileName(args[0]));
        }

        static void ProcessApple(string[] args)
        { 
            Console.WriteLine("Hello World!");

            ProcessOriginal(args[1]);

            var toBeRemoved = new List<string>();

            var document = XDocument.Load(args[0]);
            var cbdt = document.Root.Element("CBDT");

            //var glyf = new XElement("glyf");
            //document.Root.Add(glyf);

            //var glyphOrder = document.Root.Element("GlyphOrder");

            //foreach (var id in glyphOrder.Descendants("GlyphID"))
            //{
            //    var name = id.Attribute("name").Value;

            //    var ttglyph = XElement.Parse(Properties.Resources.One);
            //    ttglyph.Attribute("name").Value = name;

            //    glyf.Add(ttglyph);

            //    // <TTGlyph name="space"/>
            //}

            //var remove = document.Descendants().Where(x => x != null && x.Attribute("name")?.Value == "space").ToArray();

            //foreach (var test in remove)
            //{
            //    test.Remove();
            //}

            const string boy = "u1F466";
            const string girl = "u1F467";
            const string man = "u1F468";
            const string woman = "u1F469";



            foreach (var item in cbdt.Descendants("cbdt_bitmap_format_17"))
            {
                var original = item.Attribute("name").Value;

                var name = GetName(item.Attribute("name").Value);
                var data = item.Element("rawimagedata");//.Value;

                switch (name)
                {
                    case "male":
                        name = "u2642";
                        break;
                    case "female":
                        name = "u2640";
                        break;
                }

                var mtx = document.Descendants("mtx").Where(x => x.Attribute("name")?.Value == original);
                foreach (var child in mtx)
                {
                    if (child.Attribute("width") != null)
                    {
                        child.Attribute("width").Value = "3000";
                    }
                    else
                    {
                        child.Attribute("height").Value = "2800";
                    }
                }

                if (name.StartsWith("glyph") || name.StartsWith("uFE4E") || name.StartsWith("uFE8"))
                {
                    var ligature = document.Descendants("Ligature").FirstOrDefault(x => x.Attribute("glyph").Value == name);
                    var parent = GetName(ligature.Parent.Attribute("glyph").Value);

                    var components = ligature.Attribute("components").Value.Replace("uni", "u").Split(',').Where(x => x != "u200D").ToList();
                    var builder = new StringBuilder();

                    if (components[0] == man || components[0] == woman)
                    {
                        var temp = components[0];
                        components[0] = parent;
                        parent = temp;
                    }

                    var family = IsFamily(parent, components);
                    var kiss = IsKiss(parent, components);
                    var couple = IsCouple(parent, components);
                    var boys = 0;
                    var girls = 0;
                    var men = 0;
                    var women = 0;

                    var gender = string.Empty;
                    var skin = string.Empty;

                    if (family)
                    {
                        var items = components.Where(x => x != "u200D").ToList();
                        items.Insert(0, parent);

                        foreach (var part in items)
                        {
                            switch (part)
                            {
                                case boy:
                                    boys++;
                                    break;
                                case girl:
                                    girls++;
                                    break;
                                case man:
                                    men++;
                                    break;
                                case woman:
                                    women++;
                                    break;
                            }
                        }

                        parent = "u1F46A";
                    }
                    else if (kiss)
                    {
                        parent = "u1F48F";
                    }
                    else if (couple)
                    {
                        parent = "u1F491";
                    }

                    switch (parent)
                    {
                        case "male":
                        case "female":
                            break;
                        default:
                            builder.Append(parent);
                            break;
                    }

                    foreach (var part in components)
                    {
                        switch (part)
                        {
                            case "u1F3FB":
                                skin = ".1";
                                break;
                            case "u1F3FC":
                                skin = ".2";
                                break;
                            case "u1F3FD":
                                skin = ".3";
                                break;
                            case "u1F3FE":
                                skin = ".4";
                                break;
                            case "u1F3FF":
                                skin = ".5";
                                break;
                            case "u200D":
                                break;
                            default:
                                if (family || kiss || couple)
                                {
                                    break;
                                }

                                if (builder.Length > 0)
                                {
                                    builder.Append("_");
                                }

                                builder.Append(part);
                                break;
                        }
                    }

                    switch (parent)
                    {
                        case "male":
                            gender = ".M";
                            break;
                        case "female":
                            gender = ".W";
                            break;
                    }

                    if (skin.Length > 0)
                    {
                        builder.Append(skin);
                    }

                    if (gender.Length > 0)
                    {
                        builder.Append(gender);
                    }

                    if (family)
                    {
                        builder.Append("." + string.Empty.PadRight(men, 'M') + string.Empty.PadRight(women, 'W') + string.Empty.PadRight(girls, 'G') + string.Empty.PadRight(boys, 'B'));
                    }
                    else if (kiss)
                    {
                        builder.Append("." + (parent == man ? "M" : "W") + (components[2] == man ? "M" : "W"));
                    }
                    else if (couple)
                    {
                        builder.Append("." + (parent == man ? "M" : "W") + (components[1] == man ? "M" : "W"));
                    }

                    var newName = builder.ToString();
                    var test = _original.ContainsKey(newName);
                    if (test)
                    {
                        name = newName;
                    }
                    else
                    {
                        if (components.Count == 1 && _original.ContainsKey(components[0] + "_" + parent))
                        {
                            name = components[0] + "_" + parent;
                        }
                        else
                        {
                            Debug.WriteLine("Not found: " + newName + " - " + name);
                        }
                    }
                }
                else if (!_original.ContainsKey(name) && _original.ContainsKey(name + ".W"))
                {
                    name += ".W";
                }
                else if (name == "u1F46A")
                {
                    name += ".MWB";
                }
                else if (name == "u1F491" || name == "u1F48F")
                {
                    name += ".WM";
                }

                //using (Image<Rgba32> image = Image.Load(bytes))
                //{
                //    image.Mutate(x => x
                //         .Resize(image.Width / 2, image.Height / 2));
                //    image.Save($"output\\{name}.png"); // Automatic encoder selected based on extension.
                //}

                if (_original.TryGetValue(name, out string value))
                {
                    data.Value = value;

                    var bytes = StringToByteArray(value);

                    using (var stream = new MemoryStream())
                    {
                        using (Image<Rgba32> image = Image.Load(bytes))
                        {
                            image.Mutate(x => x.Resize(18, 18));
                            image.SaveAsPng(stream);
                            //image.Save("bar.jpg"); // Automatic encoder selected based on extension.
                        }

                        stream.Seek(0, SeekOrigin.Begin);
                        data.Value = ByteArrayToString(stream.ToArray());
                    }

                    var metrics = item.Element("SmallGlyphMetrics");
                    metrics.Element("height").Attribute("value").Value = "18";
                    metrics.Element("width").Attribute("value").Value = "18";
                    metrics.Element("BearingX").Attribute("value").Value = "1";
                    metrics.Element("BearingY").Attribute("value").Value = "15";
                    metrics.Element("Advance").Attribute("value").Value = "18";

                    /*<height value="96"/>
      <width value="96"/>
      <BearingX value="0"/>
      <BearingY value="76"/>
      <Advance value="96"/>*/

                    //File.WriteAllBytes($"output\\{name}.png", value);
                }
                else
                {
                    //File.WriteAllBytes($"output\\{name}.png", StringToByteArray(data.Value));

                    if (original != "uni2640" && original != "uni2642" && original != "uni2695")
                    {
                        toBeRemoved.Add(original);
                    }
                }

            }

            var cblc = document.Descendants("CBLC").FirstOrDefault();
            var bitmapSizeTable = cblc.Descendants("bitmapSizeTable").FirstOrDefault();

            foreach (var sbitLineMetrics in bitmapSizeTable.Elements("sbitLineMetrics"))
            {
                sbitLineMetrics.Element("ascender").Attribute("value").Value = "15";
                sbitLineMetrics.Element("descender").Attribute("value").Value = "-5";
                sbitLineMetrics.Element("widthMax").Attribute("value").Value = "20";
            }

            bitmapSizeTable.Element("ppemX").Attribute("value").Value = "14";
            bitmapSizeTable.Element("ppemY").Attribute("value").Value = "14";

            foreach (var item in toBeRemoved)
            {
                var remove1 = document.Descendants().Where(x => x != null && x.Attribute("name")?.Value == item).ToList();
                var remove2 = document.Descendants().Where(x => x != null && x.Attribute("glyph")?.Value == item).ToList();

                var name = GetName(item);
                if (name.StartsWith("u"))
                {
                    //remove1.Remove(remove1.FirstOrDefault(x => x.Name == "GlyphID"));
                    //remove1.Remove(remove1.FirstOrDefault(x => x.Name == "map"));
                    //remove1.RemoveAt(0);
                    //remove1.RemoveAt(1);
                    //remove1.RemoveAt(2);
                }

                switch (name)
                {
                    case "male":
                        name = "u2642";
                        break;
                    case "female":
                        name = "u2640";
                        break;
                }

                foreach (var test in remove1.Union(remove2))
                {
                    if (test.Name.LocalName == "LigatureSet")
                    {
                        continue;
                    }

                    if (name.StartsWith("u"))
                    {
                        if (test.Name.LocalName == "cbdt_bitmap_format_17" ||
                            test.Name.LocalName == "glyphLoc" ||
                            test.Name.LocalName == "Ligature")
                        {
                            test.Remove();
                        }
                    }
                    else
                    {
                        test.Remove();
                    }
                }
            }

            ProcessBase(args[2], document.Root);

            document.Save(Path.GetFileName(args[0]));
        }

        const string boy = "u1F466";
        const string girl = "u1F467";
        const string man = "u1F468";
        const string woman = "u1F469";

        static bool IsFamily(string parent, IList<string> components)
        {
            var items = components.ToList();
            items.Insert(0, parent);

            var test = new[] { boy, girl, man, woman };

            return items.Count >= 2 && items.Count <= 4 && items.All(x => test.Contains(x));
        }

        static bool IsCouple(string parent, IList<string> components)
        {
            //u1F48F
            return components.Count == 2 && (parent == man || parent == woman) && components[0] == "u2764" && (components[1] == man || components[1] == woman);
        }

        static bool IsKiss(string parent, IList<string> components)
        {
            //u1F48F
            return components.Count == 3 && (parent == man || parent == woman) && components[0] == "u2764" && components[1] == "u1F48B" && (components[2] == man || components[2] == woman);
        }

        static void ProcessOriginal(string path)
        {
            var document = XDocument.Load(path);
            var sbix = document.Descendants("sbix").FirstOrDefault();

            foreach (var item in sbix.Descendants("strike"))
            {
                var ppem = item.Descendants("ppem").FirstOrDefault().Attribute("value").Value;
                if (string.Equals(ppem, "160"))
                {
                    foreach (var glyph in item.Descendants("glyph").Where(x => x.HasElements))
                    {
                        var name = glyph.Attribute("name").Value;
                        var data = glyph.Element("hexdata").Value;

                        if (name.EndsWith(".0") || name.EndsWith(".0.M") || name.EndsWith(".0.W"))
                        {
                            //name = name.Substring(0, name.Length - 2);
                            name = name.Replace(".0", string.Empty);
                        }

                        _original[name] = data;

                    }

                    break;
                }
            }
        }

        static string[] _replacements = new string[] { "space", "numbersign", "asterisk", "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" /*, "male", "female"*/ };

        static Dictionary<string, string> _test = new Dictionary<string, string>
        {
            { "space", "0x20" },
            { "numbersign", "0x23" },
            { "asterisk", "0x2a" },
            { "zero", "0x30" },
            { "one", "0x31" },
            { "two", "0x32" },
            { "three", "0x33" },
            { "four", "0x34" },
            { "five", "0x35" },
            { "six", "0x36" },
            { "seven", "0x37" },
            { "eight", "0x38" },
            { "nine", "0x39" },
        };

        static void ProcessBase(string path, XElement root, bool contours = true)
        {
            var document = XDocument.Load(path);

            var hmtx = document.Root.Element("hmtx");
            var cvt = document.Root.Element("cvt");
            var fpgm = document.Root.Element("fpgm");
            var prep = document.Root.Element("prep");

            var loca = new XElement("loca");
            root.Add(loca);

            root.Add(fpgm);
            root.Add(prep);
            root.Add(cvt);

            var hmtxNew = root.Element("hmtx");

            var cmap_format_4 = new XElement("cmap_format_4");
            cmap_format_4.Add(new XAttribute("platformID", "3"));
            cmap_format_4.Add(new XAttribute("platEncID", "1"));
            cmap_format_4.Add(new XAttribute("language", "0"));

            var cmap = root.Element("cmap");
            cmap.Add(cmap_format_4);

            foreach (var item in _replacements)
            {
                var old = hmtx.Descendants("mtx").FirstOrDefault(x => x.Attribute("name").Value == item);
                var update = hmtxNew.Descendants("mtx").FirstOrDefault(x => x.Attribute("name").Value == item);

                update.Attribute("width").Value = old.Attribute("width").Value;
                update.Attribute("lsb").Value = old.Attribute("lsb").Value;

                if (_test.TryGetValue(item, out string code))
                {
                    var node = new XElement("map");
                    node.Add(new XAttribute("code", code));
                    node.Add(new XAttribute("name", item));

                    cmap_format_4.Add(node);
                }
            }

            var glyf = root.Element("glyf");
            if (glyf == null)
            {
                glyf = new XElement("glyf");
                root.Add(glyf);
            }

            foreach (var glyph in root.Element("GlyphOrder").Descendants("GlyphID"))
            {
                var name = glyph.Attribute("name").Value;
                if (_replacements.Contains(name))
                {
                    var ttglyph = document.Descendants("TTGlyph").FirstOrDefault(x => x.Attribute("name").Value == name);
                    glyf.Add(ttglyph);
                }
                else if (contours)
                {
                    var ttglyph = new XElement("TTGlyph");
                    ttglyph.Add(new XAttribute("name", name));

                    var bitmap = root.Descendants("cbdt_bitmap_format_17").FirstOrDefault(x => x.Attribute("name").Value == name);
                    if (bitmap != null)
                    {
                        var contour = new XElement("contour");
                        contour.Add(new XElement("pt", new XAttribute("x", "0"), new XAttribute("y", "0"), new XAttribute("on", "1")));
                        contour.Add(new XElement("pt", new XAttribute("x", "3000"), new XAttribute("y", "0"), new XAttribute("on", "1")));
                        contour.Add(new XElement("pt", new XAttribute("x", "3000"), new XAttribute("y", "3000"), new XAttribute("on", "1")));
                        contour.Add(new XElement("pt", new XAttribute("x", "0"), new XAttribute("y", "3000"), new XAttribute("on", "1")));

                        var instructions = new XElement("instructions");

                        ttglyph.Add(new XAttribute("xMin", "0"));
                        ttglyph.Add(new XAttribute("xMax", "3000"));
                        ttglyph.Add(new XAttribute("yMin", "0"));
                        ttglyph.Add(new XAttribute("yMax", "3000"));
                        ttglyph.Add(contour);
                        ttglyph.Add(instructions);
                    }

                    glyf.Add(ttglyph);
                }
            }

            var post1 = document.Root.Element("post");
            var post2 = root.Element("post");
            CopyNodes(post1, post2, "underlinePosition", "underlineThickness");

            var hhea1 = document.Root.Element("hhea");
            var hhea2 = root.Element("hhea");
            CopyNodes(hhea1, hhea2, "ascent", "descent", "advanceWidthMax", "minLeftSideBearing", "minRightSideBearing", "xMaxExtent");

            var os_21 = document.Root.Element("OS_2");
            var os_22 = root.Element("OS_2");
            CopyNodes(os_21, os_22, "xAvgCharWidth", "sTypoAscender", "sTypoDescender", "sTypoLineGap", "usWinAscent", "usWinDescent", "sxHeight", "sCapHeight");

            root.Element("vhea").Remove();
            root.Element("vmtx").Remove();
        }

        static void CopyNodes(XElement source, XElement dest, params string[] names)
        {
            foreach (var name in names)
            {
                dest.Element(name).Attribute("value").Value = source.Element(name).Attribute("value").Value;
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            hex = hex.Replace(" ", "").Replace("\n", "").Trim();

            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
