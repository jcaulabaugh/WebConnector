using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using ConnectorLibrary.DataProccess;
using ConnectorLibrary.Models;
using static ConnectorLibrary.Utilities.Common;

namespace ConnectorLibrary
{
    public class Convertor
    {
        /// <summary>
        /// Method for converting the JSON file to XML,
        /// in order to send the string back to the server
        /// </summary>
        /// <param name="fileName"></param>
        public static void XMLConversion(string fileName, string requestType)
        {

            string filePath = $@"C:\mcniWC\{fileName}.json";
            var fileReader = File.ReadAllText(filePath);

            var doc = JSONExtensions.DeserializeXmlNode(fileReader, $"{ fileName }QueryRs", fileName);
            string path = $@"C:\mcniWC\{ fileName }.txt";

            doc.Save(path);

            // Add attribues to parent node
            var node = doc.SelectSingleNode($"{ fileName }QueryRs");

            var att1 = doc.CreateAttribute("statusMessage");
            att1.InnerText = "Status OK";

            var att2 = doc.CreateAttribute("statusSeverity");
            att2.InnerText = "Info";

            var att3 = doc.CreateAttribute("statusCode");
            att3.InnerText = "0";

            // Append the attributes
            node.Attributes.Append(att1);
            node.Attributes.Append(att2);
            node.Attributes.Append(att3);

            // Read original Xml string and add the root element
            var StringWriter = new StringWriter();
            var xmlText = new XmlTextWriter(StringWriter);
            doc.WriteTo(xmlText);

            // Add root to the xml file
            XElement finalDoc = null;

            Enum.TryParse(requestType, out RequestType requestTypeCheck);

            switch (requestTypeCheck)
            {
                case RequestType.Sage50:
                    {
                        finalDoc = new XElement(new XElement("MCNI_Sage50_XML", XElement.Parse(StringWriter.ToString())));
                        break;
                    }
                case RequestType.Sage100:
                    {
                        finalDoc = new XElement(new XElement("MCNI_Sage100_XML", XElement.Parse(StringWriter.ToString())));
                        break;
                    }
                case RequestType.MSGP:
                    {
                        finalDoc = new XElement(new XElement("MCNI_GP_XML", XElement.Parse(StringWriter.ToString())));
                        break;
                    }
            }

            // Save Xml file
            finalDoc.Save(path);
        }
    }
}
