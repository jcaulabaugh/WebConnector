using ConnectorLibrary.DataProcess;
using ConnectorLibrary.Utilities;
using MCNiWebServiceApp.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConnectorLibrary.DataAccess
{
    class GenericConnector
    {

        /// <summary>
        /// Gets the xml data for the Generic connector request
        /// </summary>
        /// <param name="dataRequest">Name of requested file</param>
        /// <param name="xmlInfo"></param>
        /// <returns></returns>
        public static string GenericDataConnector(string dataRequest)
        {
            var returnData = "";

            try
            {
                string line;
                var filePath = "";
                var path = "";

                // Check if username and password exist in the config file
                if (File.Exists(ConfigHelper.filePath))
                {
                    var document = XDocument.Load(ConfigHelper.filePath);

                    if (document.Descendants("Generic").Any())
                    {
                        path = document.Element("Company").Element("Generic").Value;

                        filePath = $@"{path}\{dataRequest}.txt";
                    }
                }

                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("MCNI_Generic_XML",
                        new XElement($"{ dataRequest }QueryRs", new XAttribute("statusMessage", "Status OK"), new XAttribute("statusSeverity", "Info"), new XAttribute("statusCode", "0"),
                                  new XElement(dataRequest))));

                StreamReader file = new StreamReader(filePath);

                while ((line = file.ReadLine()) != null)
                {
                    var element = new XElement("DATA", line);
                    doc.Descendants(dataRequest).Last().Add(element);

                }

                ActivityLog.activityListText($"Getting { dataRequest } data");

                returnData = doc.ToString();

                returnData = returnData.Insert(0, "<?mcnixml version=\"1.0\"?>");

                return returnData;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                return returnData;
            }
        }
    }
}
