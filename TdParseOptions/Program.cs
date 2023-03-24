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
    class TdOption
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsWriteable { get; set; }
        public string Description { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var options = new Dictionary<string, TdOption>
            {
                // Setup additional options, not (yet) included in public documentation
                { "storage_max_time_from_last_access", new TdOption { Name = "storage_max_time_from_last_access", Type = "long", IsWriteable = true, Description = "TBD" } },
                { "notification_sound_count_max", new TdOption { Name = "notification_sound_count_max", Type = "long", IsWriteable = false, Description = "TBD" } },
                { "notification_sound_size_max", new TdOption { Name = "notification_sound_size_max", Type = "long", IsWriteable = false, Description = "TBD" } },
                { "notification_sound_duration_max", new TdOption { Name = "notification_sound_duration_max", Type = "long", IsWriteable = false, Description = "TBD" } },

                { "gift_premium_from_attachment_menu", new TdOption { Name = "gift_premium_from_attachment_menu", Type = "bool", IsWriteable = false, Description = "TBD" } },
                { "gift_premium_from_input_field", new TdOption { Name = "gift_premium_from_input_field", Type = "bool", IsWriteable = false, Description = "TBD" } },
                { "is_premium", new TdOption { Name = "is_premium", Type = "bool", IsWriteable = false, Description = "TBD" } },
                { "is_premium_available", new TdOption { Name = "is_premium_available", Type = "bool", IsWriteable = false, Description = "TBD" } },
                { "chat_filter_chosen_chat_count_max", new TdOption { Name = "chat_filter_chosen_chat_count_max", Type = "long", IsWriteable = false, Description = "TBD" } },
                { "chat_filter_count_max", new TdOption { Name = "chat_filter_count_max", Type = "long", IsWriteable = false, Description = "TBD" } },
                { "bio_length_max", new TdOption { Name = "bio_length_max", Type = "long", IsWriteable = false, Description = "TBD" } },
                { "anti_spam_bot_user_id", new TdOption { Name = "anti_spam_bot_user_id", Type = "long", IsWriteable = false, Description = "TBD" } },
                { "forum_member_count_min", new TdOption { Name = "forum_member_count_min", Type = "bool", IsWriteable = false, Description = "TBD" } },

                // Custom options
                { "x_system_proxy_id", new TdOption { Name = "x_system_proxy_id", Type = "long", IsWriteable = true, Description = "TBD" } }
            };

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

                if (options.ContainsKey(name))
                {
                    System.Diagnostics.Debugger.Break();
                }

                options[name] = new TdOption { Name = name, Type = type, IsWriteable = writeable, Description = description };
            }

            foreach (var option in options.Values)
            {
                var name = option.Name;
                var type = option.Type;
                var writeable = option.IsWriteable;
                var description = option.Description;

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
                if (writeable)
                {
                    cbuilder.AppendLine($"        public {type} {displayName}");
                    cbuilder.AppendLine($"        {{");
                    cbuilder.AppendLine($"            get => {privateName};");

                    cbuilder.AppendLine($"            set");
                    cbuilder.AppendLine($"            {{");
                    cbuilder.AppendLine($"                {privateName} = value;");
                    if (string.Equals(type, "string", StringComparison.OrdinalIgnoreCase))
                    {
                        cbuilder.AppendLine($"                if (value == null)");
                        cbuilder.AppendLine($"                {{");
                        cbuilder.AppendLine($"                    _clientService.Send(new SetOption(\"{name}\", new OptionValueEmpty()));");
                        cbuilder.AppendLine($"                }}");
                        cbuilder.AppendLine($"                else");
                        cbuilder.AppendLine($"                {{");
                        cbuilder.AppendLine($"                    _clientService.Send(new SetOption(\"{name}\", new {optionValue}(value)));");
                        cbuilder.AppendLine($"                }}");
                    }
                    else
                    {
                        cbuilder.AppendLine($"                _clientService.Send(new SetOption(\"{name}\", new {optionValue}(value)));");
                    }
                    cbuilder.AppendLine($"            }}");
                    cbuilder.AppendLine($"        }}");
                }
                else
                {
                    cbuilder.AppendLine($"        public {type} {displayName} => {privateName};");
                }
                cbuilder.AppendLine();

                hbuilder.AppendLine($"                case \"{name}\":");
                hbuilder.AppendLine($"                    {privateName} = GetValue<{type}>(value);");
                hbuilder.AppendLine($"                    break;");
            }

            var final = Properties.Resources.BaseFile
                .Replace("{0}", ibuilder.ToString().TrimEnd())
                .Replace("{1}", hbuilder.ToString().TrimEnd())
                .Replace("{2}", cbuilder.ToString().TrimEnd())
                .Replace("{3}", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));

            File.WriteAllText("OptionsService.cs", final);
        }

        static string GetDisplayName(string name)
        {
            // We want to ignore x_ used for custom options.
            if (name.StartsWith("x_"))
            {
                name = name.Substring(2);
            }

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
            // We want to ignore x_ used for custom options.
            if (name.StartsWith("x_"))
            {
                name = name.Substring(2);
            }

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
                    return "long";
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
                case "long":
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
