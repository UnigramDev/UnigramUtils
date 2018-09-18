using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TdParseOptions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var content = await client.GetStringAsync("https://core.telegram.org/tdlib/options");

            var document = new HtmlDocument();
            document.LoadHtml(content);

            var table = document.DocumentNode.SelectNodes("//table").LastOrDefault();

            var ibuilder = new StringBuilder();
            var cbuilder = new StringBuilder();
            var hbuilder = new StringBuilder();

            foreach (var row in table.SelectNodes(table.XPath + "//tr").Skip(1))
            {
                var name = WebUtility.HtmlDecode(row.SelectSingleNode(row.XPath + "//td[1]").InnerText);
                var type = GetType(row.SelectSingleNode(row.XPath + "//td[2]").InnerText);
                var writeable = WebUtility.HtmlDecode(row.SelectSingleNode(row.XPath + "//td[3]").InnerText).Equals("yes", StringComparison.OrdinalIgnoreCase);
                var description = GetDescription(row.SelectSingleNode(row.XPath + "//td[4]").InnerText);

                var optionValue = GetOptionValue(type);
                var displayName = GetDisplayName(name);
                var privateName = GetPrivateName(name);

                ibuilder.AppendLine($"        /// <summary>");
                ibuilder.AppendLine($"        /// {description}");
                ibuilder.AppendLine($"        /// </summary>");
                ibuilder.AppendLine($"        /// <value>{name}</value>");
                ibuilder.AppendLine($"        {type} {displayName} {(writeable ? "{ get; set; }" : "{ get; }")}");
                ibuilder.AppendLine();

                cbuilder.AppendLine($"        private {type} {privateName};");
                cbuilder.AppendLine($"        public {type} {displayName}");
                cbuilder.AppendLine($"        {{");
                cbuilder.AppendLine($"            get {{ return {privateName}; }}");

                if (writeable)
                {
                    cbuilder.AppendLine($"            set");
                    cbuilder.AppendLine($"            {{");
                    cbuilder.AppendLine($"                {privateName} = value;");
                    cbuilder.AppendLine($"                ProtoService.Send(new SetOption(\"{name}\", new {optionValue}(value)));");
                    cbuilder.AppendLine($"            }}");
                }

                cbuilder.AppendLine($"        }}");
                cbuilder.AppendLine();

                hbuilder.AppendLine($"                case \"{name}\":");
                hbuilder.AppendLine($"                    {privateName} = (({optionValue})update.Value).Value;");
                hbuilder.AppendLine($"                    break;");
            }

            var final = Properties.Resources.BaseFile
                .Replace("{0}", ibuilder.ToString())
                .Replace("{1}", hbuilder.ToString())
                .Replace("{2}", cbuilder.ToString())
                .Replace("{3}", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));

            File.WriteAllText("OptionsService.cs", final);
        }

        static string GetDisplayName(string name)
        {
            var split = name.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Empty;

            foreach (var item in split)
            {
                result += item.Substring(0, 1).ToUpper();
                result += item.Substring(1);
            }

            return result;
        }

        static string GetPrivateName(string name)
        {
            var split = name.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Empty;

            foreach (var item in split)
            {
                if (string.IsNullOrEmpty(result))
                {
                    result += $"_{item}";
                }
                else
                {
                    result += item.Substring(0, 1).ToUpper();
                    result += item.Substring(1);
                }
            }

            return result;
        }

        static string GetType(string type)
        {
            switch (type.ToLower())
            {
                case "boolean":
                    return "bool";
                case "string":
                    return "string";
                case "integer":
                    return "int";
                default:
                    return null;
            }
        }

        static string GetOptionValue(string type)
        {
            switch (type.ToLower())
            {
                case "bool":
                    return "OptionValueBoolean";
                case "string":
                    return "OptionValueString";
                case "int":
                    return "OptionValueInteger";
                default:
                    return null;
            }
        }

        static string GetDescription(string description)
        {
            return WebUtility.HtmlDecode(description).Replace("“", "\"").Replace("”", "\"");
        }
    }
}
