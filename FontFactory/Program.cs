using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SkiaSharp;

namespace FontFactory
{
    class Program
    {
        static Dictionary<string, string> _original = new Dictionary<string, string>();

        public static string BuildUri(string string2)
        {
            var result = string.Empty;
            var i = 0;

            var proc = true;

            do
            {
                proc = true;

                if (char.IsSurrogatePair(string2, i))
                {
                    if (result.Length > 0)
                        result += "_";

                    result += "u" + char.ConvertToUtf32(string2, i).ToString("x2").ToUpper();
                    i += 2;
                }
                else
                {
                    switch (string2[i])
                    {
                        case '\u2642':
                            result += ".M";
                            proc = false;
                            break;
                        case '\u2640':
                            result += ".W";
                            proc = false;
                            break;
                        case '\u200D':
                        case '\uFE0F':
                            proc = false;
                            break;
                        default:
                            if (result.Length > 0)
                                result += "_";

                            result += "u" + ((short)string2[i]).ToString("x4").ToUpper();
                            break;
                    }

                    i++;
                }

            } while (i < string2.Length);

            return result;
        }

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

        static async Task Main(string[] args)
        {
            ProcessTwemoji(new[]
            {
                @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\NotoColorEmoji.ttx",
                @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\Apple Color Emoji1.ttx",
                @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\segoeui.ttx",
                @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\seguisym.ttx"
            }, "apple", true);
            //ProcessTwemoji(new[] {
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\NotoColorEmoji.ttx",
            //    @"D:\Users\Fela\Documents\GitHub\twemoji\2\svg",
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\segoeui.ttx",
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\seguisym.ttx"
            //}, "twemoji", true);
            //ProcessTwemoji(new[] {
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\NotoColorEmoji.ttx",
            //    //@"D:\Users\Fela\Documents\GitHub\noto-emoji\svg",
            //    @"D:\Users\Fela\Pictures\Emoji\noto\compressed_pngs",
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\segoeui.ttx",
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\seguisym.ttx"
            //}, "noto", true);
            //ProcessTwemoji(new[] {
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\NotoColorEmoji.ttx",
            //    //@"D:\Users\Fela\Documents\GitHub\noto-emoji\svg",
            //    @"D:\Users\Fela\Pictures\Emoji\blobmoji\compressed_pngs",
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\segoeui.ttx",
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\seguisym.ttx"
            //}, "blobmoji", true);
            //ProcessTwemoji(new[] {
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\NotoColorEmoji.ttx",
            //    //@"D:\Users\Fela\Documents\GitHub\noto-emoji\svg",
            //    @"D:\Users\Fela\Pictures\Emoji\joypixels\compressed_pngs",
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\segoeui.ttx",
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\seguisym.ttx"
            //}, "joypixels", true);
            //ProcessTwemoji(new[] {
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\NotoColorEmoji.ttx",
            //    @"D:\Users\Fela\Pictures\Emoji\whatsapp\compressed_pngs",
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\segoeui.ttx",
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\seguisym.ttx",
            //    @"D:\Users\Fela\Documents\GitHub\twemoji\2\svg"
            //}, "whatsapp", true);
            //ProcessTwemoji(new[] {
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\NotoColorEmoji.ttx",
            //    @"D:\Users\Fela\Pictures\Emoji\facebook\compressed_pngs",
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\segoeui.ttx",
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\seguisym.ttx"
            //}, "facebook", true);
            //ProcessTwemoji(new[] {
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\NotoColorEmoji.ttx",
            //    @"D:\Users\Fela\Pictures\Emoji\samsung\compressed_pngs",
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\segoeui.ttx",
            //    @"D:\Users\Fela\Documents\Visual Studio 2017\Projects\App1\App1\Assets\seguisym.ttx"
            //}, "samsung", true);
        }

        static void ProcessTwemoji(string[] args, string output, bool quant)
        {
            Console.WriteLine("Hello World!");

            if (args.Length > 4)
            {
                ProcessWhatsappOriginal(args[1], args[4], output);
            }
            else if (args[1].EndsWith(".ttx"))
            {
                ProcessOriginal(args[1]);
            }
            else
            {
                ProcessTwemojiOriginal(args[1], output);
            }

            var toBeRemoved = new List<string>();

            var document = XDocument.Load(args[0]);
            var cbdt = document.Root.Element("CBDT");

            var cbdtStrike1 = cbdt.Element("strikedata");
            var cbdtStrike2 = new XElement(cbdtStrike1);

            cbdtStrike2.Attribute("index").Value = "1";
            cbdt.Add(cbdtStrike2);

            foreach (var namerecord in document.Descendants("namerecord"))
            {
                var value = namerecord.Value.Replace("\n", "").Trim();
                if (value == "EmojiOne" || value == "Noto Color Emoji")
                {
                    namerecord.Value = "Segoe UI Emoji";
                }
            }

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



            foreach (var item in cbdtStrike1.Descendants("cbdt_bitmap_format_17"))
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

                var ligature = document.Descendants("Ligature").FirstOrDefault(x => x.Attribute("glyph").Value == original);
                //if (name.StartsWith("glyph") || name.StartsWith("uFE4E") || name.StartsWith("uFE8"))
                if (ligature != null)
                {
                    //var ligature = document.Descendants("Ligature").FirstOrDefault(x => x.Attribute("glyph").Value == name);
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
                        if (_original.ContainsKey(original))
                        {
                            name = original;
                        }
                        //else if (_original.ContainsKey(newName.Substring(0, newName.Length - 2)))
                        //{
                        //    name = newName.Substring(0, newName.Length - 2);
                        //}
                        else if (string.Equals(newName, "u1F1E8_u1F1F5"))
                        {
                            name = "u1F1EB_u1F1F7";
                        }
                        else if (string.Equals(newName, "u1F1FA_u1F1F2"))
                        {
                            name = "u1F1FA_u1F1F8";
                        }
                        else if (string.Equals(newName, "u1F1EA_u1F1E6"))
                        {
                            name = "u1F1EA_u1F1F8";
                        }
                        else if (string.Equals(original, "glyph01508"))
                        {
                            name = "u1F1F3_u1F1F4";
                        }
                        else if (components.Count == 1 && _original.ContainsKey(components[0] + "_" + parent))
                        {
                            name = components[0] + "_" + parent;
                        }
                        else if (!_original.ContainsKey(newName) && char.IsDigit(newName[newName.Length - 1]) && newName[newName.Length - 2] == '.')
                        {
                            name = newName.Substring(0, newName.Length - 2);
                        }
                        else
                        {
                            Debug.WriteLine("Not found: " + newName + " - " + name);
                        }
                    }
                }

                if (!_original.ContainsKey(name) && _original.ContainsKey(name + ".M"))
                {
                    name += ".M";
                }
                else if (!_original.ContainsKey(name) && _original.ContainsKey(name + ".W"))
                {
                    name += ".W";
                }
                else if (!_original.ContainsKey(name) && char.IsDigit(name[name.Length - 1]) && name[name.Length - 2] == '.')
                {
                    name = name.Substring(0, name.Length - 2);
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

                    {
                        if (quant)
                        {
                            if (!File.Exists($"{output}output\\{name}-small-fs8.png"))
                            {
                                using (Image<Rgba32> image = Image.Load(bytes))
                                {
                                    image.Mutate(x => x.Resize(new ResizeOptions
                                    {
                                        Size = new SixLabors.Primitives.Size(18, 18),
                                        Mode = ResizeMode.Pad
                                    }));
                                    image.Save($"{output}output\\{name}-small.png", new PngEncoder { CompressionLevel = 1 });
                                }

                                Process.Start("pngquant", $"{output}output\\{name}-small.png").WaitForExit();
                            }

                            data.Value = ByteArrayToString(File.ReadAllBytes($"{output}output\\{name}-small-fs8.png"));
                        }
                        else
                        {
                            using (var stream = new MemoryStream())
                            {
                                using (Image<Rgba32> image = Image.Load(bytes))
                                {
                                    image.Mutate(x => x.Resize(18, 18));
                                    image.SaveAsPng(stream);
                                }

                                stream.Seek(0, SeekOrigin.Begin);
                                data.Value = ByteArrayToString(stream.ToArray());
                            }
                        }

                        var metrics = item.Element("SmallGlyphMetrics");
                        metrics.Element("height").Attribute("value").Value = "18";
                        metrics.Element("width").Attribute("value").Value = "18";
                        metrics.Element("BearingX").Attribute("value").Value = "1";
                        metrics.Element("BearingY").Attribute("value").Value = "15";
                        metrics.Element("Advance").Attribute("value").Value = "18";
                    }

                    {
                        var item2 = cbdtStrike2.Descendants("cbdt_bitmap_format_17").FirstOrDefault(x => x.Attribute("name").Value == original);
                        var data2 = item2.Element("rawimagedata");//.Value;

                        if (quant)
                        {
                            if (!File.Exists($"{output}output\\{name}-fs8.png"))
                            {
                                using (Image<Rgba32> image = Image.Load(bytes))
                                {
                                    image.Mutate(x => x.Resize(new ResizeOptions
                                    {
                                        Size = new SixLabors.Primitives.Size(64, 64),
                                        Mode = ResizeMode.Pad
                                    }));
                                    image.Save($"{output}output\\{name}.png", new PngEncoder { CompressionLevel = 1 });
                                }

                                Process.Start("pngquant", $"{output}output\\{name}.png").WaitForExit();
                            }

                            data2.Value = ByteArrayToString(File.ReadAllBytes($"{output}output\\{name}-fs8.png"));
                        }
                        else
                        {
                            using (var stream = new MemoryStream())
                            {
                                using (Image<Rgba32> image = Image.Load(bytes))
                                {
                                    image.Mutate(x => x.Resize(64, 64));
                                    image.SaveAsPng(stream);
                                }

                                stream.Seek(0, SeekOrigin.Begin);
                                data2.Value = ByteArrayToString(stream.ToArray());
                            }
                        }

                        var metrics = item2.Element("SmallGlyphMetrics");
                        metrics.Element("height").Attribute("value").Value = "64";
                        metrics.Element("width").Attribute("value").Value = "64";
                        metrics.Element("BearingX").Attribute("value").Value = "6";
                        metrics.Element("BearingY").Attribute("value").Value = "54";
                        metrics.Element("Advance").Attribute("value").Value = "64";
                    }
                }
                else
                {
                    File.WriteAllBytes($"failure\\{original}.png", StringToByteArray(data.Value));

                    //if (original != "uni2640" && original != "uni2642" /*&& original != "uni2695"*/)
                    {
                        toBeRemoved.Add(original);
                    }
                }

            }

            var cblc = document.Descendants("CBLC").FirstOrDefault();

            var cblcStrike1 = cblc.Element("strike");
            var cblcStrike2 = new XElement(cblcStrike1);

            cblcStrike2.Attribute("index").Value = "1";
            cblc.Add(cblcStrike2);

            {
                var bitmapSizeTable = cblcStrike1.Element("bitmapSizeTable");

                foreach (var sbitLineMetrics in bitmapSizeTable.Elements("sbitLineMetrics"))
                {
                    sbitLineMetrics.Element("ascender").Attribute("value").Value = "15";
                    sbitLineMetrics.Element("descender").Attribute("value").Value = "-5";
                    sbitLineMetrics.Element("widthMax").Attribute("value").Value = "20";
                }

                bitmapSizeTable.Element("ppemX").Attribute("value").Value = "14";
                bitmapSizeTable.Element("ppemY").Attribute("value").Value = "14";
            }

            {
                var bitmapSizeTable = cblcStrike2.Element("bitmapSizeTable");

                foreach (var sbitLineMetrics in bitmapSizeTable.Elements("sbitLineMetrics"))
                {
                    sbitLineMetrics.Element("ascender").Attribute("value").Value = "54";
                    sbitLineMetrics.Element("descender").Attribute("value").Value = "-10";
                    sbitLineMetrics.Element("widthMax").Attribute("value").Value = "64";
                }

                bitmapSizeTable.Element("ppemX").Attribute("value").Value = "50";
                bitmapSizeTable.Element("ppemY").Attribute("value").Value = "50";
            }

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

            //ProcessMissing(document.Root, quant);
            ProcessBase(args[2], args[3], document.Root);

            document.Save(Path.GetFileName(args[0]));
        }




        //static void ProcessMissing(XElement root, bool quant)
        //{
        //    var lastId = root.Descendants("GlyphID").LastOrDefault();
        //    var maxId = int.Parse(lastId.Attribute("id")?.Value ?? "0");

        //    var lastLoc = root.Descendants("glyphLoc").LastOrDefault();
        //    var maxLoc = int.Parse(lastId.Attribute("id")?.Value ?? "0");

        //    maxId++;
        //    maxLoc++;

        //    var glyphOrder = root.Element("GlyphOrder");
        //    var hmtx = root.Element("hmtx");
        //    var cbdt = root.Element("CBDT");
        //    var cblc = root.Element("CBLC");

        //    var strikedata1 = cbdt.Elements("strikedata").FirstOrDefault();
        //    var strikedata2 = cbdt.Elements("strikedata").LastOrDefault();

        //    var strike1 = cblc.Elements("strike").FirstOrDefault();
        //    var strike2 = cblc.Elements("strike").LastOrDefault();

        //    var eblc_index_sub_table_11 = new XElement("eblc_index_sub_table_1");
        //    var eblc_index_sub_table_12 = new XElement("eblc_index_sub_table_1");

        //    strike1.Add(eblc_index_sub_table_11);
        //    strike2.Add(eblc_index_sub_table_12);

        //    foreach (var missing in _missing)
        //    {
        //        var apple = BuildUri(missing);
        //        if (_original.TryGetValue(apple, out string value))
        //        {
        //            var name = "glyph" + maxId.ToString().PadLeft(5, '0');
        //            var bytes = StringToByteArray(value);

        //            glyphOrder.Add(new XElement("GlyphID", new XAttribute("id", maxId.ToString()), new XAttribute("name", name)));
        //            hmtx.Add(new XElement("mtx", new XAttribute("name", name), new XAttribute("width", "3000"), new XAttribute("lsb", "0")));

        //            {
        //                var cbdt_bitmap_format_17 = new XElement("cbdt_bitmap_format_17");
        //                var data = new XElement("rawimagedata");

        //                if (quant)
        //                {
        //                    //using (Image<Rgba32> image = Image.Load(bytes))
        //                    //{
        //                    //    image.Mutate(x => x.Resize(18, 18));
        //                    //    image.Save($"output\\{original}-small.png", new PngEncoder { CompressionLevel = 1 });
        //                    //}

        //                    //Process.Start("pngquant", $"output\\{original}-small.png").WaitForExit();

        //                    data.Value = ByteArrayToString(File.ReadAllBytes($"output\\{name}-small-fs8.png"));
        //                }
        //                else
        //                {
        //                    using (var stream = new MemoryStream())
        //                    {
        //                        using (Image<Rgba32> image = Image.Load(bytes))
        //                        {
        //                            image.Mutate(x => x.Resize(18, 18));
        //                            image.SaveAsPng(stream);
        //                        }

        //                        stream.Seek(0, SeekOrigin.Begin);
        //                        data.Value = ByteArrayToString(stream.ToArray());
        //                    }
        //                }

        //                var metrics = new XElement("SmallGlyphMetrics");
        //                metrics.Element("height").Attribute("value").Value = "18";
        //                metrics.Element("width").Attribute("value").Value = "18";
        //                metrics.Element("BearingX").Attribute("value").Value = "1";
        //                metrics.Element("BearingY").Attribute("value").Value = "15";
        //                metrics.Element("Advance").Attribute("value").Value = "18";

        //                cbdt_bitmap_format_17.Add(metrics);
        //                cbdt_bitmap_format_17.Add(data);

        //                strikedata1.Add(cbdt_bitmap_format_17);
        //            }

        //            {
        //                var cbdt_bitmap_format_17 = new XElement("cbdt_bitmap_format_17");
        //                var data = new XElement("rawimagedata");

        //                if (quant)
        //                {
        //                    //using (Image<Rgba32> image = Image.Load(bytes))
        //                    //{
        //                    //    image.Mutate(x => x.Resize(64, 64));
        //                    //    image.Save($"output\\{original}.png", new PngEncoder { CompressionLevel = 1 });
        //                    //}

        //                    //Process.Start("pngquant", $"output\\{original}.png").WaitForExit();

        //                    data.Value = ByteArrayToString(File.ReadAllBytes($"output\\{name}-fs8.png"));
        //                }
        //                else
        //                {
        //                    using (var stream = new MemoryStream())
        //                    {
        //                        using (Image<Rgba32> image = Image.Load(bytes))
        //                        {
        //                            image.Mutate(x => x.Resize(64, 64));
        //                            image.SaveAsPng(stream);
        //                        }

        //                        stream.Seek(0, SeekOrigin.Begin);
        //                        data.Value = ByteArrayToString(stream.ToArray());
        //                    }
        //                }

        //                var metrics = new XElement("SmallGlyphMetrics");
        //                metrics.Element("height").Attribute("value").Value = "64";
        //                metrics.Element("width").Attribute("value").Value = "64";
        //                metrics.Element("BearingX").Attribute("value").Value = "6";
        //                metrics.Element("BearingY").Attribute("value").Value = "54";
        //                metrics.Element("Advance").Attribute("value").Value = "64";

        //                cbdt_bitmap_format_17.Add(metrics);
        //                cbdt_bitmap_format_17.Add(data);

        //                strikedata2.Add(cbdt_bitmap_format_17);
        //            }

        //            eblc_index_sub_table_11.Add(new XElement("glyphLoc", new XAttribute("id", maxLoc.ToString()), new XAttribute("name", name)));
        //            eblc_index_sub_table_12.Add(new XElement("glyphLoc", new XAttribute("id", maxLoc.ToString()), new XAttribute("name", name)));
        //        }
        //        else
        //        {
        //            return;
        //        }

        //        maxId++;
        //        maxLoc++;
        //    }

        //}

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

        static void ProcessTwemojiOriginal(string path, string output)
        {
            var files = Directory.GetFiles(path);
            var svg = new SkiaSharp.Extended.Svg.SKSvg();

            if (!Directory.Exists(output))
            {
                Directory.CreateDirectory(output);
            }

            if (!Directory.Exists($"{output}output"))
            {
                Directory.CreateDirectory($"{output}output");
            }

            foreach (var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);
                name = name.Replace("emoji_u", string.Empty).Replace('_', '-');
                name = "u" + name.ToUpper().Replace("-", "_u");
                name = name.Replace("U", "u");
                name = name.Replace("_u200D", string.Empty);
                name = name.Replace("_uFE0F", string.Empty);
                name = name.Replace("_u2642", "_male");
                name = name.Replace("_u2640", "_female");
                //name = name.Replace("_u2642", ".M");
                //name = name.Replace("_u2640", ".W");
                //name = name.Replace("_u1F3FB", ".1");
                //name = name.Replace("_u1F3FC", ".2");
                //name = name.Replace("_u1F3FD", ".3");
                //name = name.Replace("_u1F3FE", ".4");
                //name = name.Replace("_u1F3FF", ".5");

                name = GetNameY(name);

                switch (name)
                {
                    case "u002A":
                    case "u0023":
                    case "u0030":
                    case "u0031":
                    case "u0032":
                    case "u0033":
                    case "u0034":
                    case "u0035":
                    case "u0036":
                    case "u0037":
                    case "u0038":
                    case "u0039":
                        continue;
                }

                if (!File.Exists($"{output}\\{name}.png"))
                {
                    if (Path.GetExtension(file) == ".svg")
                    {
                        var quality = 100;

                        var pict = svg.Load(file);
                        var dimen = new SKSizeI(160, 160);
                        var matrix = SKMatrix.MakeScale(160f / pict.CullRect.Width, 160f / pict.CullRect.Width);
                        var img = SKImage.FromPicture(pict, dimen, matrix);

                        // convert to PNG
                        var skdata = img.Encode(SKEncodedImageFormat.Png, quality);
                        using (var stream = File.OpenWrite($"{output}\\{name}.png"))
                        {
                            skdata.SaveTo(stream);
                        }

                        _original[name] = ByteArrayToString(skdata.ToArray());
                    }
                    else if (Path.GetExtension(file) == ".png")
                    {
                        _original[name] = ByteArrayToString(File.ReadAllBytes(file));
                    }
                }
                else
                {
                    _original[name] = ByteArrayToString(File.ReadAllBytes($"{output}\\{name}.png"));
                }
            }
        }

        static void ProcessWhatsappOriginal(string path, string mapping, string output)
        {
            var files = Directory.GetFiles(mapping);

            if (!Directory.Exists(output))
            {
                Directory.CreateDirectory(output);
            }

            if (!Directory.Exists($"{output}output"))
            {
                Directory.CreateDirectory($"{output}output");
            }

            foreach (var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);
                var emoji = GetEmoji(name);

                name = name.Replace("emoji_u", string.Empty).Replace('_', '-');
                name = "u" + name.ToUpper().Replace("-", "_u");
                name = name.Replace("U", "u");
                name = name.Replace("_u200D", string.Empty);
                name = name.Replace("_uFE0F", string.Empty);
                name = name.Replace("_u2642", "_male");
                name = name.Replace("_u2640", "_female");
                //name = name.Replace("_u2642", ".M");
                //name = name.Replace("_u2640", ".W");
                //name = name.Replace("_u1F3FB", ".1");
                //name = name.Replace("_u1F3FC", ".2");
                //name = name.Replace("_u1F3FD", ".3");
                //name = name.Replace("_u1F3FE", ".4");
                //name = name.Replace("_u1F3FF", ".5");

                name = GetNameY(name);

                switch (name)
                {
                    case "u002a":
                    case "u0023":
                    case "u0030":
                    case "u0031":
                    case "u0032":
                    case "u0033":
                    case "u0034":
                    case "u0035":
                    case "u0036":
                    case "u0037":
                    case "u0038":
                    case "u0039":
                        continue;
                }

                var test = new C0914b(emoji);
                var result = Test.getDescriptor(test);

                if (result == -1)
                {
                    continue;
                }

                var boh = 16777215 & result;
                var code = boh + 1;

                var original = code.ToString().PadLeft(4, '0');

                _original[name] = ByteArrayToString(File.ReadAllBytes($"{path}\\e{original}.png"));
            }
        }


        static string GetEmoji(string name)
        {
            var builder = new StringBuilder();
            var split = name.Split('-');

            foreach (var item in split)
            {
                int value = int.Parse(item, System.Globalization.NumberStyles.HexNumber);
                var count = CharCount(value);

                if (count > 1)
                {
                    builder.Append(char.ConvertFromUtf32(value));
                }
                else
                {
                    builder.Append((char)value);
                }
            }

            return builder.ToString();
        }

        public static int CharCount(int codePoint)
        {
            return codePoint >= 0x10000 ? 2 : 1;
        }

        static string GetNameY(string path)
        {
            var split = path.Split('_');

            for (int i = 0; i < split.Length; i++)
            {
                if (split[i].Length == 3)
                {
                    split[i] = "u00" + split[i].Substring(1);
                }
            }

            var parent = split[0];
            var components = split.Skip(1).ToList();
            var builder = new StringBuilder();

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
                    case "uFE0F":
                        break;
                    case "male":
                        gender = ".M";
                        break;
                    case "female":
                        gender = ".W";
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

            return builder.ToString();
        }

        static string[] _replacements = new string[]
        {
            "space",
            "numbersign",
            "asterisk",
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "male",
            "female",
            "uni2695",

            "u1F1E6",
            "u1F1E7",
            "u1F1E8",
            "u1F1E9",
            "u1F1EA",
            "u1F1EB",
            "u1F1EC",
            "u1F1ED",
            "u1F1EE",
            "u1F1EF",
            "u1F1F0",
            "u1F1F1",
            "u1F1F2",
            "u1F1F3",
            "u1F1F4",
            "u1F1F5",
            "u1F1F6",
            "u1F1F7",
            "u1F1F8",
            "u1F1F9",
            "u1F1FA",
            "u1F1FB",
            "u1F1FC",
            "u1F1FD",
            "u1F1FE",
            "u1F1FF"
        };

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
            { "male", "0x2642" },
            { "female", "0x2640" },
            { "uni2695", "0x2695" },

            { "u1F1E6", "0x1F1E6" },
            { "u1F1E7", "0x1F1E7" },
            { "u1F1E8", "0x1F1E8" },
            { "u1F1E9", "0x1F1E9" },
            { "u1F1EA", "0x1F1EA" },
            { "u1F1EB", "0x1F1EB" },
            { "u1F1EC", "0x1F1EC" },
            { "u1F1ED", "0x1F1ED" },
            { "u1F1EE", "0x1F1EE" },
            { "u1F1EF", "0x1F1EF" },
            { "u1F1F0", "0x1F1F0" },
            { "u1F1F1", "0x1F1F1" },
            { "u1F1F2", "0x1F1F2" },
            { "u1F1F3", "0x1F1F3" },
            { "u1F1F4", "0x1F1F4" },
            { "u1F1F5", "0x1F1F5" },
            { "u1F1F6", "0x1F1F6" },
            { "u1F1F7", "0x1F1F7" },
            { "u1F1F8", "0x1F1F8" },
            { "u1F1F9", "0x1F1F9" },
            { "u1F1FA", "0x1F1FA" },
            { "u1F1FB", "0x1F1FB" },
            { "u1F1FC", "0x1F1FC" },
            { "u1F1FD", "0x1F1FD" },
            { "u1F1FE", "0x1F1FE" },
            { "u1F1FF", "0x1F1FF" }
        };

        static void ProcessBase(string path1, string path2, XElement root, bool contours = true)
        {
            var document1 = XDocument.Load(path1);
            var document2 = XDocument.Load(path2);

            var hmtx1 = document1.Root.Element("hmtx");
            var hmtx2 = document2.Root.Element("hmtx");
            var cvt = document1.Root.Element("cvt");
            var fpgm = document1.Root.Element("fpgm");
            var prep = document1.Root.Element("prep");
            var gasp = document1.Root.Element("gasp");

            var loca = new XElement("loca");
            root.Add(loca);

            root.Add(fpgm);
            root.Add(prep);
            root.Add(cvt);
            root.Add(gasp);

            var hmtxNew = root.Element("hmtx");

            var cmap_format_4 = new XElement("cmap_format_4");
            cmap_format_4.Add(new XAttribute("platformID", "3"));
            cmap_format_4.Add(new XAttribute("platEncID", "1"));
            cmap_format_4.Add(new XAttribute("language", "0"));

            var cmap = root.Element("cmap");
            cmap.Add(cmap_format_4);

            foreach (var item in _replacements)
            {
                var old = hmtx1.Descendants("mtx").FirstOrDefault(x => x.Attribute("name").Value == item) ?? hmtx2.Descendants("mtx").FirstOrDefault(x => x.Attribute("name").Value == item);
                var update = hmtxNew.Descendants("mtx").FirstOrDefault(x => x.Attribute("name").Value == item);
                if (update == null)
                {
                    continue;
                }

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
                    var ttglyph = document1.Descendants("TTGlyph").FirstOrDefault(x => x.Attribute("name").Value == name) ?? document2.Descendants("TTGlyph").FirstOrDefault(x => x.Attribute("name").Value == name);
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

            var post1 = document1.Root.Element("post");
            var post2 = root.Element("post");
            CopyNodes(post1, post2, "underlinePosition", "underlineThickness");

            var hhea1 = document1.Root.Element("hhea");
            var hhea2 = root.Element("hhea");
            CopyNodes(hhea1, hhea2, "ascent", "descent", "advanceWidthMax", "minLeftSideBearing", "minRightSideBearing", "xMaxExtent");

            var os_21 = document1.Root.Element("OS_2");
            var os_22 = root.Element("OS_2");
            CopyNodes(os_21, os_22, "xAvgCharWidth", "sTypoAscender", "sTypoDescender", "sTypoLineGap", "usWinAscent", "usWinDescent", "sxHeight", "sCapHeight");

            var maxp1 = document1.Root.Element("maxp");
            var maxp2 = root.Element("maxp");
            CopyNodes(maxp1, maxp2, "numGlyphs", "maxPoints", "maxContours", "maxCompositePoints", "maxCompositeContours", "maxZones", "maxTwilightPoints", "maxStorage", "maxFunctionDefs", "maxInstructionDefs", "maxStackElements", "maxSizeOfInstructions", "maxComponentElements", "maxComponentDepth");

            root.Element("vhea").Remove();
            root.Element("vmtx").Remove();

            return;



            var LTSH1 = document1.Root.Element("LTSH");
            var LTSH2 = document2.Root.Element("LTSH");
            var VDMX = document1.Root.Element("VDMX");
            var hdmx1 = document1.Root.Element("hdmx");
            var hdmx2 = document2.Root.Element("hdmx");

            var ltshNew = new XElement("LTSH");
            var hdmxNew = new XElement("hdmx");

            var hdmxData1 = hdmx1.Element("hdmxData");
            var hdmxLines1 = hdmxData1.Value.Split('\n');

            var hdmxData2 = hdmx2.Element("hdmxData");
            var hdmxLines2 = hdmxData2.Value.Split('\n');

            var hdmxBuilder = new StringBuilder();
            hdmxBuilder.AppendLine();
            hdmxBuilder.Append("                      ppem:  11  12  13  15  16  17  19  21  24  27  29  32  33  37  42  46  50 ;");
            hdmxBuilder.AppendLine();

            foreach (var glyph in root.Element("GlyphOrder").Descendants("GlyphID"))
            {
                //ltshNew.Add(LTSH1.Descendants("yPel").FirstOrDefault(x => x.Attribute("name").Value == item) ?? LTSH2.Descendants("yPel").FirstOrDefault(x => x.Attribute("name").Value == item));
                //vdmxNew.Add(VDMX1.Descendants("yPel").FirstOrDefault(x => x.Attribute("name").Value == item) ?? VDMX2.Descendants("yPel").FirstOrDefault(x => x.Attribute("name").Value == item));
                var name = glyph.Attribute("name").Value;

                if (_replacements.Contains(name))
                {
                    var line = hdmxLines1.FirstOrDefault(x => x.Trim().ToLower().StartsWith(name + ":")) ?? hdmxLines2.FirstOrDefault(x => x.Trim().ToLower().StartsWith(name + ":"));
                    if (line != null)
                    {
                        hdmxBuilder.AppendLine(line);
                    }
                }
                else
                {
                    hdmxBuilder.AppendLine(name.PadLeft(26, ' ') + ":  11  12  13  15  16  17  19  21  24  27  29  32  33  37  42  46  50 ;");
                }
            }

            hdmxNew.Add(new XElement("hdmxData", hdmxBuilder.ToString()));

            //root.Add(ltshNew);
            //root.Add(vdmxNew);
            root.Add(hdmxNew);

            root.Add(VDMX);
            //root.Add(hdmx);
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
