using System.IO;
using System.Linq;
using System.Xml.Linq;
using ConnectorLibrary.Utilities;

namespace WebConnectorApp.AppHelper
{
    public class IconText
    {
        /// <summary>
        /// Method for setting the text of the NotifyIcon
        /// </summary>
        /// <returns></returns>
        public static string IconTextCheck()
        {
            // The text
            string iconText = "";

            if (Directory.Exists(GlobalConfig.filePath()))
            {
                if (File.Exists(GlobalConfig.fileName()))
                {
                    var doc = XDocument.Load(GlobalConfig.fileName());

                    if (doc.Descendants("MCNI_Username").Any() && doc.Descendants("ConnectionString").Any())
                    {
                        iconText = "MCNI Web Connector \nUser Authenticated \nActive Status";
                    }
                    else if (doc.Descendants("MCNI_Username").Any() && doc.Descendants("Sage100").Any())
                    {
                        iconText = "MCNI Web Connector \nUser Authenticated \nActive Status";
                    }
                    else if (doc.Descendants("MCNI_Username").Any() && !doc.Descendants("ConnectionString").Any())
                    {
                        iconText = "MCNI Web Connector \nUser Authenticated \nInactive Status";
                    }
                    else if ((!doc.Descendants("MCNI_Username").Any() && doc.Descendants("ConnectionString").Any()))
                    {
                        iconText = "MCNI Web Connector \nUser Not Authenticated \nInactive Status";
                    }
                }
                else
                {
                    iconText = "MCNI Web Connector \nUser Not Authenticated \nInactive Status";
                }
            }
            else
            {
                iconText = "MCNI Web Connector \nUser not Authenticated \nInactive Status";
            }

            return iconText;
        }


    }
}
