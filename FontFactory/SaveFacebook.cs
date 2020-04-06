using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace FontFactory
{
    public class SaveFacebook
    {
        static Dictionary<string, string> _existing = new Dictionary<string, string>();

        public static async Task DownloadAll()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://emojipedia.org/samsung/");

            var document = new HtmlDocument();
            document.LoadHtml(response);

            var ul = document.DocumentNode.SelectSingleNode("//ul[@class='emoji-grid']");

            var writeCustomerBlock = new ActionBlock<Tuple<string, string>>(async url =>
            {
                var name = url.Item2;

                Console.WriteLine("Downloading: " + name);

                var stream = await client.GetStreamAsync(url.Item1);
                using (var file = File.Create(@"C:\Users\Fela\Pictures\Emoji\samsung\compressed_pngs\" + name))
                {
                    stream.CopyTo(file);
                }
            }, new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = 15
            });

            foreach (var li in ul.SelectNodes(ul.XPath + "//img"))
            {
                var url = (li.Attributes["data-cfsrc"] ?? li.Attributes["data-src"] ?? li.Attributes["src"]).Value;
                var name = url.Split('/').Last();

                if (name.Count(x => x == '_') > 1)
                {
                    var index = name.IndexOf('_');
                    index = name.IndexOf('_', index + 1);

                    name = name.Substring(index + 1);
                }
                else
                {
                    name = name.Split('_').Last();
                }

                if (_existing.ContainsKey(name))
                {
                    Console.WriteLine("Skipping: " + name);
                    continue;
                }

                _existing[name] = url;
                writeCustomerBlock.Post(Tuple.Create(url, name));
            };

            writeCustomerBlock.Complete();
        }
    }
}
