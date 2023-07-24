using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ConnectorLibrary.Utilities
{
    /// <summary>
    /// This class is responsible for building and editing the mcni_config xml file
    /// </summary>
    public class ConfigHelper
    {
        public static string folderPath = GlobalConfig.filePath();
        public static string filePath = GlobalConfig.fileName();

        private static void _directoryCheck()
        {
            if (!Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }
        }

        /// <summary>
        /// This method inputs the MCNI username and password into the config file
        /// </summary>
        /// <param name="username">MCNI Username</param>
        /// <param name="password">MCNI Password</param>
        public static void ConfigBuilder(string username, string password)
        {
            _directoryCheck();

            if (File.Exists(filePath))
            {
                var doc = XDocument.Load(filePath);

                if (!doc.Descendants("MCNI_Username").Any() && !doc.Descendants("MCNI_Password").Any())
                {
                    doc.Element("Company").Add(
                               new XElement
                                ("MCNI_Username", username),
                               new XElement
                                ("MCNI_Password", password));
                }
                else
                {
                    doc.Element("Company").Element("MCNI_Username").Value = username;
                    doc.Element("Company").Element("MCNI_Password").Value = password;
                }

                doc.Save(filePath);

            }
            else if (!File.Exists(filePath))
            {
                XDocument doc = new XDocument(
                                           new XDeclaration("1.0", "gb2312", string.Empty),
                                               new XElement("Company",
                                                   new XElement("MCNI_Username", username),
                                                   new XElement("MCNI_Password", password),
                                                   new XElement("Server", "https://www.mcni360wctest.com"),
                                                   new XElement("Run_Every_Minutes", 5)));
                doc.Save(filePath);
            }
        }

        public static void ConfigSage100Builder(string path, string company, string username, string password)
        {
            _directoryCheck();

            if (File.Exists(filePath))
            {
                var doc = XDocument.Load(filePath);

                if (!doc.Descendants("Sage100").Any())
                {
                    doc.Element("Company").Add(
                               new XElement("Sage100",
                                   new XElement("Sage100_Path", path),
                                   new XElement("Sage100_Company", company),
                                   new XElement("Sage100_Username", username),
                                   new XElement("Sage100_Password", password)
                                    )
                               );
                }
                else
                {
                    doc.Element("Company").Element("Sage100").Element("Sage100_Path").Value = path;
                    doc.Element("Company").Element("Sage100").Element("Sage100_Company").Value = company;
                    doc.Element("Company").Element("Sage100").Element("Sage100_Username").Value = username;
                    doc.Element("Company").Element("Sage100").Element("Sage100_Password").Value = password;
                }

                doc.Save(filePath);

            }
            else if (!File.Exists(filePath))
            {
                XDocument doc = new XDocument(
                                            new XDeclaration("1.0", "gb2312", string.Empty),
                                                new XElement("Company",
                                                    new XElement("Sage100",
                                                        new XElement("Sage100_Path", path),
                                                        new XElement("Sage100_Company", company),
                                                        new XElement("Sage100_Username", username),
                                                        new XElement("Sage100_Password", password)
                                                        ),
                                                    new XElement("Server", "https://www.mcni360wctest.com"),
                                                    new XElement("Run_Every_Minutes", 5)
                                                   )
                                                );

                doc.Save(filePath);
            }
        }

        public static void ConfigSage50Builder(string company, string datasourceName, string datasourcePassword)
        {
            _directoryCheck();

            if (File.Exists(filePath))
            {
                var doc = XDocument.Load(filePath);

                if (!doc.Descendants("Sage50").Any())
                {
                    doc.Element("Company").Add(
                               new XElement("Sage50",
                                   new XElement("Sage50_Company", company),
                                   new XElement("Sage50_Datasource_Name", datasourceName),
                                   new XElement("Sage50_Datasource_Password", datasourcePassword),
                                   new XElement("Sage50_appID", @"E0DwgUjZOzr5aSMSa1axUkkY7w76QyihO5c2YgPWoXhpYShkB8pwyw==wxgCfp/FcwRX4pkdnL/aQ2djwiS6jnMJ1CjYFzv0Sif6dFYRaOWVMAgJkEfR+2gCv1fnwHfcFq0fc/JMj/saokPWmhKpGTabySat4fAqWYnZr+iUIVDXcG+He/jou0Zt3hNvcEM+EpqnbDqDxIUyqOW+MQ6FxyqNIG0ovBOMtyscU/6z/kRHOJssjq1wtK4boq76Bf7pXZGEJ8nIAARPcJ0HM6+FPxNriin2NO4QRvuWu+i2rDSh3TONhfDWj6Ws")
                                    )
                               );
                }
                else
                {
                    doc.Element("Company").Element("Sage50").Element("Sage50_Company").Value = company;
                    doc.Element("Company").Element("Sage50").Element("Sage50_Datasource_Name").Value = datasourceName;
                    doc.Element("Company").Element("Sage50").Element("Sage50_Datasource_Password").Value = datasourcePassword;
                }

                doc.Save(filePath);

            }
            else if (!File.Exists(filePath))
            {
                XDocument doc = new XDocument(
                                            new XDeclaration("1.0", "gb2312", string.Empty),
                                                new XElement("Company",
                                                    new XElement("Sage50",
                                                        new XElement("Sage50_Company", company),
                                                        new XElement("Sage50_Datasource_Name", datasourceName),
                                                        new XElement("Sage50_Datasource_Password", datasourcePassword),
                                                        new XElement("Sage50_appID", @"E0DwgUjZOzr5aSMSa1axUkkY7w76QyihO5c2YgPWoXhpYShkB8pwyw==wxgCfp/FcwRX4pkdnL/aQ2djwiS6jnMJ1CjYFzv0Sif6dFYRaOWVMAgJkEfR+2gCv1fnwHfcFq0fc/JMj/saokPWmhKpGTabySat4fAqWYnZr+iUIVDXcG+He/jou0Zt3hNvcEM+EpqnbDqDxIUyqOW+MQ6FxyqNIG0ovBOMtyscU/6z/kRHOJssjq1wtK4boq76Bf7pXZGEJ8nIAARPcJ0HM6+FPxNriin2NO4QRvuWu+i2rDSh3TONhfDWj6Ws")
                                                        ),
                                                    new XElement("Server", "https://www.mcni360wctest.com"),
                                                    new XElement("Run_Every_Minutes", 5)
                                                   )
                                                );

                doc.Save(filePath);
            }
        }

        /// <summary>
        /// Method for populating the config file with the connectionstring details
        /// </summary>
        /// <param name="dataSource">Server</param>
        /// <param name="database">Database</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        public static void ConfigMSGPBuilder(string dataSource, string database, string username = "", string password = "", string id = "")
        {
            // Connection string
            string conn = $@"Server={ dataSource }; Initial Catalog={ database }; Integrated Security=SSPI; User ID={ username }; Password={ password }";

            _directoryCheck();

            if (File.Exists(filePath))
            {
                var doc = XDocument.Load(filePath);

                if (!doc.Descendants("ConnectionString").Any())
                {
                    doc.Element("Company").Add(
                               new XElement("ConnectionString", conn),
                               new XElement("eConnectDOCID", id));
                }
                else
                {
                    doc.Element("Company").Element("ConnectionString").Value = conn;
                    doc.Element("Company").Element("eConnectDOCID").Value = id;
                }

                doc.Save(filePath);

            }
            else if (!File.Exists(filePath))
            {
                XDocument doc = new XDocument(
                                            new XDeclaration("1.0", "gb2312", string.Empty),
                                                new XElement("Company",
                                                    new XElement("ConnectionString", conn),
                                                    new XElement("eConnectDOCID", id),
                                                    new XElement("Server", "https://www.mcni360wctest.com"),
                                                    new XElement("Run_Every_Minutes", 5)));
                doc.Save(filePath);
            }
        }

        /// <summary>
        /// Method for checking if user info is present in config file
        /// </summary>
        /// <returns></returns>
        public static bool configCheck()
        {
            _directoryCheck();

            if (File.Exists(filePath))
            {
                var doc = XDocument.Load(filePath);

                if (doc.Descendants("MCNI_Username").Any() && doc.Descendants("MCNI_Password").Any() && doc.Descendants("ConnectionString").Any())
                {
                    return true;
                }
                else if (doc.Descendants("MCNI_Username").Any() && doc.Descendants("MCNI_Password").Any() && doc.Descendants("Sage100").Any())
                {
                    return true;
                }
                else if (doc.Descendants("MCNI_Username").Any() && doc.Descendants("MCNI_Password").Any() && doc.Descendants("Sage50").Any())
                {
                    return true;
                }
                else if (doc.Descendants("MCNI_Username").Any() && doc.Descendants("MCNI_Password").Any() && doc.Descendants("Generic").Any())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Method for inserting the 'Last_Run' time stamp in the config file
        /// </summary>
        public static void TimeStamp()
        {
            if (File.Exists(filePath))
            {
                var doc = XDocument.Load(filePath);

                if (!doc.Descendants("Last_Run").Any())
                {
                    doc.Element("Company").Add(
                            new XElement("Last_Run", DateTime.Now.ToString()));
                }
                else
                {
                    doc.Element("Company").Element("Last_Run").Value = DateTime.Now.ToString();
                }
                doc.Save(filePath);
            }
        }
    }
}

