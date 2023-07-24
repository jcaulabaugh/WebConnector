using System.IO;
using System.Xml;
using Newtonsoft.Json;


namespace ConnectorLibrary.DataProccess
{
    public static partial class JSONExtensions
    {
        public static XmlDocument DeserializeXmlNode(string json, string rootName, string rootPropertyName)
        {
            return DeserializeXmlNode(new StringReader(json), rootName, rootPropertyName);
        }

        public static XmlDocument DeserializeXmlNode(TextReader textReader, string rootName, string rootPropertyName)
        {
            var prefix = "{" + JsonConvert.SerializeObject(rootPropertyName) + ":";
            var postfix = "}";

            using (var combinedReader = new StringReader(prefix).Concat(textReader).Concat(new StringReader(postfix)))
            {
                var settings = new JsonSerializerSettings
                {
                    Converters = { new Newtonsoft.Json.Converters.XmlNodeConverter() { DeserializeRootElementName = rootName } },
                    DateParseHandling = DateParseHandling.None,
                };
                using (var jsonReader = new JsonTextReader(combinedReader) { CloseInput = false, DateParseHandling = DateParseHandling.None })
                {
                    return JsonSerializer.CreateDefault(settings).Deserialize<XmlDocument>(jsonReader);
                }
            }
        }
    }
}
