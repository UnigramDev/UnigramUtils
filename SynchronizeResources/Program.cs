using System.Security;
using System.Xml.Linq;

namespace SynchronizeResources
{
    class Program
    {
        public static void Main(string[] args)
        {
            var remote = XDocument.Load("https://translations.telegram.org/en/unigram/export");
            if (remote.Root == null)
            {
                return;
            }

            var nodes = new Dictionary<string, string>();

            foreach (var item in remote.Root.Descendants("string"))
            {
                var name = item.Attribute("name");
                if (name != null)
                {
                    nodes[name.Value] = item.Value;
                }
            }

            WriteResw(nodes);
            WriteCs(nodes);
        }

        private static void WriteResw(Dictionary<string, string> nodes)
        {
            var writer = new StreamWriter(new FileStream(@"C:\Source\Telegram\Telegram\Strings\en\Resources.resw", FileMode.Create));
            writer.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n");
            writer.Write("<root>\r\n");
            writer.Write("  <xsd:schema id=\"root\" xmlns=\"\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">\r\n");
            writer.Write("    <xsd:import namespace=\"http://www.w3.org/XML/1998/namespace\" />\r\n");
            writer.Write("    <xsd:element name=\"root\" msdata:IsDataSet=\"true\">\r\n");
            writer.Write("      <xsd:complexType>\r\n");
            writer.Write("        <xsd:choice maxOccurs=\"unbounded\">\r\n");
            writer.Write("          <xsd:element name=\"metadata\">\r\n");
            writer.Write("            <xsd:complexType>\r\n");
            writer.Write("              <xsd:sequence>\r\n");
            writer.Write("                <xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" />\r\n");
            writer.Write("              </xsd:sequence>\r\n");
            writer.Write("              <xsd:attribute name=\"name\" use=\"required\" type=\"xsd:string\" />\r\n");
            writer.Write("              <xsd:attribute name=\"type\" type=\"xsd:string\" />\r\n");
            writer.Write("              <xsd:attribute name=\"mimetype\" type=\"xsd:string\" />\r\n");
            writer.Write("              <xsd:attribute ref=\"xml:space\" />\r\n");
            writer.Write("            </xsd:complexType>\r\n");
            writer.Write("          </xsd:element>\r\n");
            writer.Write("          <xsd:element name=\"assembly\">\r\n");
            writer.Write("            <xsd:complexType>\r\n");
            writer.Write("              <xsd:attribute name=\"alias\" type=\"xsd:string\" />\r\n");
            writer.Write("              <xsd:attribute name=\"name\" type=\"xsd:string\" />\r\n");
            writer.Write("            </xsd:complexType>\r\n");
            writer.Write("          </xsd:element>\r\n");
            writer.Write("          <xsd:element name=\"data\">\r\n");
            writer.Write("            <xsd:complexType>\r\n");
            writer.Write("              <xsd:sequence>\r\n");
            writer.Write("                <xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />\r\n");
            writer.Write("                <xsd:element name=\"comment\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"2\" />\r\n");
            writer.Write("              </xsd:sequence>\r\n");
            writer.Write("              <xsd:attribute name=\"name\" type=\"xsd:string\" use=\"required\" msdata:Ordinal=\"1\" />\r\n");
            writer.Write("              <xsd:attribute name=\"type\" type=\"xsd:string\" msdata:Ordinal=\"3\" />\r\n");
            writer.Write("              <xsd:attribute name=\"mimetype\" type=\"xsd:string\" msdata:Ordinal=\"4\" />\r\n");
            writer.Write("              <xsd:attribute ref=\"xml:space\" />\r\n");
            writer.Write("            </xsd:complexType>\r\n");
            writer.Write("          </xsd:element>\r\n");
            writer.Write("          <xsd:element name=\"resheader\">\r\n");
            writer.Write("            <xsd:complexType>\r\n");
            writer.Write("              <xsd:sequence>\r\n");
            writer.Write("                <xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />\r\n");
            writer.Write("              </xsd:sequence>\r\n");
            writer.Write("              <xsd:attribute name=\"name\" type=\"xsd:string\" use=\"required\" />\r\n");
            writer.Write("            </xsd:complexType>\r\n");
            writer.Write("          </xsd:element>\r\n");
            writer.Write("        </xsd:choice>\r\n");
            writer.Write("      </xsd:complexType>\r\n");
            writer.Write("    </xsd:element>\r\n");
            writer.Write("  </xsd:schema>\r\n");
            writer.Write("  <resheader name=\"resmimetype\">\r\n");
            writer.Write("    <value>text/microsoft-resx</value>\r\n");
            writer.Write("  </resheader>\r\n");
            writer.Write("  <resheader name=\"version\">\r\n");
            writer.Write("    <value>2.0</value>\r\n");
            writer.Write("  </resheader>\r\n");
            writer.Write("  <resheader name=\"reader\">\r\n");
            writer.Write("    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>\r\n");
            writer.Write("  </resheader>\r\n");
            writer.Write("  <resheader name=\"writer\">\r\n");
            writer.Write("    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>\r\n");
            writer.Write("  </resheader>\r\n");

            foreach (var entry in nodes.OrderBy(x => x.Key))
            {
                if (string.IsNullOrEmpty(entry.Value))
                {
                    continue;
                }

                if (entry.Key.EndsWith("_zero")
                    || entry.Key.EndsWith("_two")
                    || entry.Key.EndsWith("_few")
                    || entry.Key.EndsWith("_many"))
                {
                    continue;
                }

                writer.Write($"  <data name=\"{entry.Key}\" xml:space=\"preserve\">\r\n");
                writer.Write($"    <value>{SecurityElement.Escape(Escape(entry.Value.Replace("\\n", "\r\n")))}</value>\r\n");
                writer.Write($"  </data>\r\n");
            }

            writer.Write("</root>");
            writer.Dispose();
        }

        private static void WriteCs(Dictionary<string, string> nodes)
        {
            var writer = new StreamWriter(new FileStream(@"C:\Source\Telegram\Telegram\Strings\en\Resources.cs", FileMode.Create));
            writer.Write("// --------------------------------------------------------------------------------------------------\r\n");
            writer.Write("// <auto-generatedInfo>\r\n");
            writer.Write("//  This code was generated by TdParseOptions (http://github.com/UnigramDev/UnigramUtils/)\r\n");
            writer.Write("//\r\n");
            writer.Write("// \tGenerated: " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "\r\n");
            writer.Write("// </auto-generatedInfo>\r\n");
            writer.Write("// --------------------------------------------------------------------------------------------------\r\n");
            writer.Write("namespace Telegram\r\n");
            writer.Write("{\r\n");
            writer.Write("    using Telegram.Services;\r\n");
            writer.Write("\r\n");
            writer.Write("    public sealed partial class Strings\r\n");
            writer.Write("    {\r\n");
            writer.Write("        private static readonly ILocaleService Resource;\r\n");
            writer.Write("\r\n");
            writer.Write("        static Strings()\r\n");
            writer.Write("        {\r\n");
            writer.Write("            Resource = LocaleService.Current;\r\n");
            writer.Write("        }\r\n");
            writer.Write("\r\n");
            writer.Write("        public static class R\r\n");
            writer.Write("        {\r\n");

            var plurals = new HashSet<string>();

            foreach (var entry in nodes.OrderBy(x => x.Key))
            {
                if (string.IsNullOrEmpty(entry.Value))
                {
                    continue;
                }

                if (entry.Key.EndsWith("_zero")
                    || entry.Key.EndsWith("_one")
                    || entry.Key.EndsWith("_two")
                    || entry.Key.EndsWith("_few")
                    || entry.Key.EndsWith("_many")
                    || entry.Key.EndsWith("_other"))
                {
                    var key = entry.Key
                        .Split('_')
                        .First();
                    if (plurals.Contains(key))
                    {
                        continue;
                    }

                    plurals.Add(key);
                    writer.Write($"            public const string {key} = \"{key}\";\r\n");
                }
            }

            writer.Write("        }\r\n");
            writer.Write("\r\n");

            foreach (var entry in nodes.OrderBy(x => x.Key))
            {
                if (string.IsNullOrEmpty(entry.Value))
                {
                    continue;
                }

                if (entry.Key.EndsWith("_zero")
                    || entry.Key.EndsWith("_one")
                    || entry.Key.EndsWith("_two")
                    || entry.Key.EndsWith("_few")
                    || entry.Key.EndsWith("_many")
                    || entry.Key.EndsWith("_other"))
                {
                    continue;
                }

                writer.Write("        /// <summary>\r\n");
                writer.Write($"        /// Localized resource similar to \"{Escape(entry.Value.Replace("\\n", "\r\n        ///"))}\"\r\n");
                writer.Write("        /// </summary>\r\n");
                writer.Write($"        public static string {entry.Key}\r\n");
                writer.Write("        {\r\n");
                writer.Write("            get\r\n");
                writer.Write("            {\r\n");
                writer.Write($"                return Resource.GetString(\"{entry.Key}\");\r\n");
                writer.Write("            }\r\n");
                writer.Write("        }\r\n");
                writer.Write("        \r\n");
            }

            writer.Write("    }\r\n");
            writer.Write("}\r\n");
            writer.Dispose();
        }

        private static string Escape(string value)
        {
            return value
                .Replace("\\\"", "\"")
                .Replace("\\'", "'");
        }
    }
}
