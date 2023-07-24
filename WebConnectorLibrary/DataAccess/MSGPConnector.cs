using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using ConnectorLibrary.DataProcess;
using ConnectorLibrary.Utilities;
using Microsoft.Dynamics.GP.eConnect;
using MCNiWebServiceApp.Utilities;
using ConnectorLibrary.Models.DBModel;
using static ConnectorLibrary.Utilities.Common;

namespace ConnectorLibrary.DataAccess
{
    public class MSGPConnector
    {
        /// <summary>
        /// Method for connecting to the database
        /// to retrieve the requested table
        /// </summary>
        /// <param name="tableInfo">Model containing the table name and date</param>
        /// <returns></returns>
        public static string ReadMSGPTable(Dictionary<string, string> tableInfo)
        {
            try
            {

             /*   SqlDataReader dataReader = null;
                var SqlString = "";
                string tableName = tableInfo["Name"];
                string date = "";
                
                if (tableInfo.ContainsKey("Date"))
                {
                    date = tableInfo["Date"];
                }

         
                string jsonData = "";

                string result = "";*/

                // Connection string
                string conn = "";

                if (File.Exists(GlobalConfig.fileName()))
                {
                    var doc = XDocument.Load(GlobalConfig.fileName());

                    if (doc.Descendants("ConnectionString").Any())
                    {
                        conn = doc.Element("Company").Element("ConnectionString").Value;
                    }
                }

                /*     DBContext db = new DBContext(conn);

                     Enum.TryParse(tableName, out MSGPTable tableRequestCheck);

                     switch (tableRequestCheck)
                     {
                         case MSGPTable.SY01200:
                             {
                                 var data = db.BarCodeTable.Select(row => row).ToList();
                        *//*         if (!string.IsNullOrEmpty(date))
                                 {
                                     data = db.BarCodeTable.Select(row => row).Where(i > i.DEX_ROW_TS.ToString() > date));
                                 }*//*

                                 result = MSGPDataProcessor(data, tableName);
                                 break;
                             }
                         case MSGPTable.RM00101:
                             {
                                 var data = db.CustomerTable.Select(row => row).ToList();
                                 result = MSGPDataProcessor(data, tableName);
                                 break;
                             }
                         case MSGPTable.IV00101:
                             {
                                 var data = db.ItemTable.Select(row => row).ToList();
                                 result = MSGPDataProcessor(data, tableName);
                                 break;
                             }
                         case MSGPTable.IV00102:
                             {
                                 var data = db.ItemLocationTable.Select(row => row).ToList();
                                 result = MSGPDataProcessor(data, tableName);
                                 break;
                             }
                         case MSGPTable.IV00105:
                             {
                                 var data = db.ItemSecondListTable.Select(row => row).ToList();
                                 result = MSGPDataProcessor(data, tableName);
                                 break;
                             }
                         case MSGPTable.IV00111:
                             {
                                 var data = db.LocationsTable.Select(row => row).ToList();
                                 result = MSGPDataProcessor(data, tableName);
                                 break;
                             }
                         case MSGPTable.IV00108:
                             {
                                 var data = db.PriceLevelTable.Select(row => row).ToList();
                                 result = MSGPDataProcessor(data, tableName);
                                 break;
                             }
                         case MSGPTable.RM00301:
                             {
                                 var data = db.SalesRepTable.Select(row => row).ToList();
                                 result = MSGPDataProcessor(data, tableName);
                                 break;
                             }
                         case MSGPTable.RM00102:
                             {
                                 var data = db.ShippingAddressTable.Select(row => row).ToList();
                                 result = MSGPDataProcessor(data, tableName);
                                 break;
                             }
                         case MSGPTable.TX00201:
                             {
                                 var data = db.TaxCodeTable.Select(row => row).ToList();
                                 result = MSGPDataProcessor(data, tableName);
                                 break;
                             }
                         case MSGPTable.TX00102:
                             {
                                 var data = db.TaxLineTable.Select(row => row).ToList();
                                 result = MSGPDataProcessor(data, tableName);
                                 break;
                             }
                         case MSGPTable.TX00101:
                             {
                                 var data = db.TaxScheduleTable.Select(row => row).ToList();
                                 result = MSGPDataProcessor(data, tableName);
                                 break;
                             }
                         case MSGPTable.IV40202:
                             {
                                 var data = db.UnitsOfMeasureTable.Select(row => row).ToList();
                                 result = MSGPDataProcessor(data, tableName);
                                 break;
                             }
                     }*/

              /*  var output = JSONGenerator.Serialize(data); */

               /*     jsonData = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);*/

                // Save table data to json file using tableinfo(name of table)
                /*            jsonData.SaveToJSONFile(tableName);*/

                // Convert JSON to xml to send back to server
                /*        Convertor.XMLConversion(tableName); */


                /* Alternatively (This translates to the above statement):
                 * var customers = from row in db.customerTable
                 *                 select row;
                 */


                // Connecting to db
                     SqlCommand command;
                     SqlDataReader dataReader = null;
                     var SqlString = "";
                     string tableName = tableInfo["Name"];
                     var date = "";
                     string jsonData = "";

                     if (tableInfo.ContainsKey("Date"))
                     {
                         date = tableInfo["Date"];
                     }

                     // Set the sql command
                     if (!string.IsNullOrEmpty(date))
                     {
                         SqlString = $"SELECT TOP 100000 * FROM { tableName } WHERE DEX_ROW_TS >= { date }";
                     }
                     else
                     {
                         SqlString = $"SELECT TOP 100000 * FROM { tableName }";
                     }

                     ActivityLog.activityListText($"Processing (Accounting Sync) { tableName } { date }");

               
                         if (File.Exists(GlobalConfig.fileName()))
                         {
                             var doc = XDocument.Load(GlobalConfig.fileName());

                             if (doc.Descendants("ConnectionString").Any())
                             {
                                 conn = doc.Element("Company").Element("ConnectionString").Value;
                             }
                         }

                         // Connecting to the sql server
                         using (SqlConnection connection = new SqlConnection(conn))
                         {
                             connection.Open();
                             command = new SqlCommand(SqlString, connection);
                             dataReader = command.ExecuteReader();
                             var output = JSONGenerator.Serialize(dataReader);

                             dataReader.Close();

                             jsonData = JsonConvert.SerializeObject(output, Newtonsoft.Json.Formatting.Indented);
                         }

                         // Save table data to json file using tableinfo(name of table)
                         jsonData.SaveToJSONFile(tableName);

                         // Convert JSON to xml to send back to server
                         Convertor.XMLConversion(tableName, "MSGP");
                
                return "True";
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                return "false";
            }

        }

        public static string MSGPDataProcessor<T>(List<T> data, string tableName)
        {
            try
            {
                string jsonData = "";
                /*           var output = JSONGenerator.Serialize(data);*/

                foreach (var item in data)
                {
                    var stringProperties = item.GetType().GetProperties()
                          .Where(p => p.PropertyType == typeof(string));

                    foreach (var stringProperty in stringProperties)
                    {
                        string currentValue = (string)stringProperty.GetValue(item, null);
                        stringProperty.SetValue(item, currentValue.Trim(), null);
                    }
                }

                jsonData = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

                // Save table data to json file using tableinfo(name of table)
                jsonData.SaveToJSONFile(tableName);

                // Convert JSON to xml to send back to server
                Convertor.XMLConversion(tableName, "MSGP");

                ActivityLog.activityListText($"Syncing { tableName }");


                return "True";
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                return "false";
            }
        }

        /// <summary>
        /// Method for processing the MSGP eConnect data
        /// </summary>
        /// <param name="data">the xml string returned by the server</param>
        /// <returns></returns>
        public static string MSGPFileProcessor(string data)
        {
            try
            {
                bool eConnectResult;
                var returnData = "";

                // Load the xml file
                XmlDocument document = new XmlDocument();
                document.LoadXml(data);

                // Connection string
                string filePath = ConfigHelper.filePath;
                var conn = "";

                // Checking for connection string
                if (File.Exists(filePath))
                {
                    var doc = XDocument.Load(filePath);

                    if (doc.Descendants("ConnectionString").Any())
                    {
                        conn = doc.Element("Company").Element("ConnectionString").Value;
                    }
                }

                // Pulling the invoice number out of the string
                string invoiceNumber = XmlParser.getInvoiceNumber(data);

                // Logging the activity to the activity list
                if (data.Contains("SOPTransactionType"))
                {
                    ActivityLog.activityListText($"Processing (Sales Transaction) invoice { invoiceNumber }");
                }
                else if (data.Contains("IVInventoryTransferType"))
                {
                    ActivityLog.activityListText($"Processing invoice (Inventory Transaction) invoice { invoiceNumber }");
                }

                using (eConnectMethods eConnect = new eConnectMethods())
                {
                    // Result of eConnect connection
                    eConnectResult = eConnect.CreateEntity(conn, document.OuterXml);

                    if (eConnectResult)
                    {
                        returnData = "True";
                    }
                    else
                    {
                        returnData = "ERROR";
                    }
                }

                return returnData;
            }
            catch (Exception ex)
            {
                var returnData = XmlParser.XMLStringFormatter(ex.Message);
                ExceptionLogger.LogException(ex);
                return returnData;
            }
        }
    }
}
    







