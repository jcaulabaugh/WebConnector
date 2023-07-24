using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Configuration;
using Newtonsoft.Json;
using ConnectorLibrary.DataProcess;
using ConnectorLibrary.Models;
using ConnectorLibrary.Utilities;
using MCNiWebServiceApp.Utilities;


namespace ConnectorLibrary.DataAccess
{
    /// <summary>
    /// The class contains all logic for connecting to Sage 100
    /// </summary>
    public class Sage100Connector
    {
        /// <summary>
        /// Testing the user info provided in the Sage100Config form
        /// </summary>
        /// <param name="path"></param>
        /// <param name="company"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void Sage100ConnectionTest(string path, string company, string username, string password)
        {
            // Set dispatch object
            using (DispatchObject pvx = new DispatchObject("ProvideX.Script"))
            {
                pvx.InvokeMethod("Init", path);

                using (DispatchObject oSS = new DispatchObject(pvx.InvokeMethod("NewObject", "SY_Session")))
                {
                    object usernamePasswordTest = 0;
                    object companyTest = 0;

                    companyTest = oSS.InvokeMethod("nSetCompany", company);
                    usernamePasswordTest = oSS.InvokeMethod("nSetUser", username, password);

                    // Sage will return 0 if the method fails, or 1 on success
                    if (usernamePasswordTest.ToString() != "0" && companyTest.ToString() != "0")
                    {
                        ConnectionTestModel.Sage100ConnectionStatus = true;
                    }
                }
            }
        }

        /// <summary>
        /// Method for reading table from the Sage 100 database
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <returns></returns>
        public string ReadSage100Table(Dictionary<string, string> tableInfo)
        {

            var tableName = tableInfo["Name"];
            var SqlString = $"{ ConfigurationManager.AppSettings[Common.SAGE_COMMAND] } { tableName }";

            string connectionString = null;
            string jsonData = "";

            // Check config file for user details
            string filePath = ConfigHelper.filePath;
            try
            {
                if (File.Exists(ConfigHelper.filePath))
                {
                    var doc = XDocument.Load(filePath);

                    if (doc.Descendants("Sage100").Any())
                    {
                        var company = doc.Element("Company").Element("Sage100").Element("Sage100_Company").Value;
                        var username = doc.Element("Company").Element("Sage100").Element("Sage100_Username").Value;
                        var password = doc.Element("Company").Element("Sage100").Element("Sage100_Password").Value;
                        connectionString = $@"DSN=SOTAMAS90; Company={ company }; UID={ username }; PWD={ password }";

                        ActivityLog.activityListText($"Processing (Accounting Sync) { tableName }");
                    }
                }

                // Connect using ODBC
                using (OdbcConnection cnn = new OdbcConnection(connectionString))
                {

                    OdbcCommand cmd = new OdbcCommand(SqlString, cnn);
                    cnn.Open();

                    OdbcDataReader reader = cmd.ExecuteReader();

                    var output = JSONGenerator.Serialize(reader);

                    // If the requested table is Customers, then TaxExemption numbers are required in the xml return
                    if (tableName == "AR_Customer")
                    {
                        // Querying the AR_CustomerShipToTaxExemptions table to get the required TaxExemption numbers
                        SqlString = $"{ ConfigurationManager.AppSettings[Common.SAGE_COMMAND] } AR_CustomerShipToTaxExemptions";

                        cmd = new OdbcCommand(SqlString, cnn);
                        reader = cmd.ExecuteReader();
                        var outputAddition = JSONGenerator.Serialize(reader);

                        foreach (var row in output)
                        {
                            foreach (var rowAddition in outputAddition)
                            {
                                if (row["CustomerNo"].Equals(rowAddition["CustomerNo"]) && rowAddition["TaxExemptionNo"].ToString() != "")
                                {

                                    row["TaxExemptNo"] = rowAddition["TaxExemptionNo"];
                                }
                            }
                        }
                    }

                    jsonData = JsonConvert.SerializeObject(output, Formatting.Indented);

                    // Save table data to json file using tableinfo(name of table)
                    jsonData.SaveToJSONFile(tableName);

                    // Convert JSON to xml to send back to server
                    Convertor.XMLConversion(tableName, "Sage100");
                }

                    return "True";

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                return "false";
            }
        }

        /// <summary>
        /// Method for checking if values were written into Sage 100 correctly
        /// </summary>
        /// <param name="serviceObject">The Sage 100 business object</param>
        /// <param name="checkValue">Checking the status of the method</param>
        /// <param name="call">The Sage 100 method name</param>
        public static void successCheck(DispatchObject serviceObject, int checkValue, string call)
        {
          /*  Exception sageInfoCheck = new Exception($"{ call } { DateTime.Now.ToString("yyyy - MM - dd hh: mm:ss") }");
            ExceptionLogger.LogException(sageInfoCheck);
*/
            // 0 indicates and error, 1 or 2 indicates success
            if (checkValue == 0)
            {
                ActivityLog.activityListText($"{ call } - error");
                Exception sageException = new Exception($" { call } - { serviceObject.InvokeMethod("sLastErrorMsg").ToString() }");
                ExceptionLogger.LogException(sageException);
            }
        }

        /// <summary>
        /// Method for checking if the header object was succesfully written into Sage 100
        /// </summary>
        /// <param name="serviceObject">The Sage 100 business object</param>
        /// <param name="checkValue">Checking the status of the method</param>
        /// <param name="call">The Sage 100 method name</param>
        /// <returns>A string that is sent eventually sent back to the server as a response to the Sage 100 input</returns>
        public static string Sage100HeaderWriteSuccessCheck(DispatchObject serviceObject, int checkValue, string call)
        {
            string response;

            if (checkValue.ToString() == "1")
            {
                ActivityLog.activityListText($"Header successfully written");
                response = "True";

                Exception sageInfoCheck = new Exception($"{ call } { DateTime.Now.ToString("yyyy - MM - dd hh: mm:ss") }");
                ExceptionLogger.LogException(sageInfoCheck);
            }
            else
            {
                ActivityLog.activityListText($"ERROR - Header did not write");
                response = "ERROR - Header did not write";
                Exception sageException = new Exception($" { call } - { serviceObject.InvokeMethod("sLastErrorMsg").ToString() }");
                ExceptionLogger.LogException(sageException);
            }

            return response;
        }

        /// <summary>
        /// Method for inputting sales order invoices or inventory transactions into the Sage 100 database
        /// </summary>
        /// <param name="headerInfo"></param>
        /// <param name="lineInfo"></param>
        /// <returns></returns>
        public static string sage100Processor(Dictionary<string, string> headerInfo, List<Dictionary<string, string>> lineInfo)
        {
            try
            {
                string path;
                string company;
                string username;
                string password;
                string responseMessage = "";

                string filePath = ConfigHelper.filePath;

                // Check the config file for the users information
                if (File.Exists(ConfigHelper.filePath))
                {
                    var doc = XDocument.Load(filePath);

                    if (doc.Descendants("Sage100").Any())
                    {
                        company = doc.Element("Company").Element("Sage100").Element("Sage100_Company").Value;
                        username = doc.Element("Company").Element("Sage100").Element("Sage100_Username").Value;
                        password = doc.Element("Company").Element("Sage100").Element("Sage100_Password").Value;
                        path = doc.Element("Company").Element("Sage100").Element("Sage100_Path").Value;

                        using (DispatchObject pvx = new DispatchObject("ProvideX.Script"))
                        {

                            //  Setting the date
                            string accDate = DateTime.Now.ToString("yyyyMMdd");

                            pvx.InvokeMethod("Init", path);

                            object retVal = null;
                            string module = "";
                            string msg = "";

                            if (Sage100InsertModel.InsertType == "SO_Invoice")
                            {
                                module = "S/O";
                                msg = "Sales Transaction";
                            }
                            else if (Sage100InsertModel.InsertType == "IM_Transaction")
                            {
                                module = "I/M";
                                msg = "Inventory Transaction";
                            }

                            ActivityLog.activityListText($"Inputting Sage 100 { msg } for company { company }");

                            using (DispatchObject oSS = new DispatchObject(pvx.InvokeMethod("NewObject", "SY_Session")))
                            {
                                // Set up task ID number
                                int TaskID = 0;

                                // Set company, log user in, set date, and set module
                                successCheck(oSS, (int)oSS.InvokeMethod("nSetCompany", company), "SetCompany");
                                successCheck(oSS, (int)oSS.InvokeMethod("nSetUser", username, password), "SetUser");
                                successCheck(oSS, (int)oSS.InvokeMethod("nSetDate", module, accDate), "SetDate");
                                successCheck(oSS, (int)oSS.InvokeMethod("nSetModule", module), "SetModule");

                                // Look up task ID and set the program
                                TaskID = (int)oSS.InvokeMethod("nLookupTask", Sage100InsertModel.InsertType + "_ui");
                                successCheck(oSS, (int)oSS.InvokeMethod("nSetProgram", TaskID), "SetProgram");

                                // using (DispatchObject so_order = new DispatchObject(pvx.InvokeMethod("NewObject", "SO_SalesOrder_bus", oSS.GetObject())))
                                using (DispatchObject headerObject = new DispatchObject(pvx.InvokeMethod("NewObject", Sage100InsertModel.InsertType + "_bus", oSS.GetObject())))
                                {
                                    if (Sage100InsertModel.InsertType == "IM_Transaction")
                                    {
                                        // Set the key values of the header object
                                        successCheck(headerObject, (int)headerObject.InvokeMethod("nSetKeyValue", "TransactionType$", headerInfo["TransactionType$"]), "SetHeaderKey TransactionType");
                                        successCheck(headerObject, (int)headerObject.InvokeMethod("nSetKeyValue", "EntryNo$", headerInfo["EntryNo$"]), "SetHeaderKey EntryNo");
                                        successCheck(headerObject, (int)headerObject.InvokeMethod("nSetKey"), "SetKey");

                                        // Remove header key elements from reference string
                                        headerInfo.Remove("TransactionType$");
                                        headerInfo.Remove("EntryNo$");
                                    }
                                    else if (Sage100InsertModel.InsertType == "SO_Invoice")
                                    {
                                        // Select the batch no
                                        object[] arr1Results = new object[] { headerInfo["BatchNo$"] };
                                        successCheck(headerObject, (int)headerObject.InvokeMethodByRef("nSelectBatch", arr1Results), "Select Batch No");
                                        var strBatchNo = arr1Results[0].ToString();

                                        // Set the batch no
                                        successCheck(headerObject, (int)headerObject.InvokeMethod("nSetValue", "BatchNo$", strBatchNo), "SetBatchNo");
                                        headerInfo.Remove("BatchNo$");

                                        //var invoiceNo = "";
                                        //successCheck(headerObject, (int)headerObject.InvokeMethod("nGetValue", "InvoiceNo$", headerInfo["InvoiceNo$"]), "CheckInvoiceNo");
                                       

                                        // Set header key
                                        Exception exx = new Exception($" inputting invoice No. { headerInfo["InvoiceNo$"] }");
                                        ExceptionLogger.LogException(exx);
                                        successCheck(headerObject, (int)headerObject.InvokeMethod("nSetKey", headerInfo["InvoiceNo$"]), "SetKey");

                                        // Remove header key element from reference string
                                        headerInfo.Remove("InvoiceNo$");
                                    }

                                    // Header entry
                                    foreach (KeyValuePair<string, string> headerEntry in headerInfo)
                                    {
                                        if (!String.IsNullOrEmpty(headerEntry.Value))
                                        {
                                            // Check if value expected by sage needs to be a string or float
                                            if (!headerEntry.Key.Contains("$"))
                                            {
                                                successCheck(headerObject, (int)headerObject.InvokeMethod("nSetValue", headerEntry.Key, float.Parse(headerEntry.Value)), headerEntry.Key);
                                            }
                                            else
                                            {
                                                successCheck(headerObject, (int)headerObject.InvokeMethod("nSetValue", headerEntry.Key, headerEntry.Value), headerEntry.Key);
                                            }
                                        }
                                    }

                                    using (DispatchObject oLines = new DispatchObject(headerObject.GetProperty("oLines")))
                                    {
                                        retVal = (int)oLines.InvokeMethod("nMoveFirst");

                                        if (retVal.ToString() == "0")
                                        {
                                            // Lines entry, Loop thorugh list of entries
                                            foreach (Dictionary<string, string> lineEntries in lineInfo)
                                            {
                                                retVal = oLines.InvokeMethod("nAddLine");

                                                // Line entry, Loop through each entry
                                                foreach (KeyValuePair<string, string> lineEntry in lineEntries)
                                                {
                                                    if (!String.IsNullOrEmpty(lineEntry.Value))
                                                    {
                                                        // Check if value expected by sage needs to be a string or float
                                                        if (!lineEntry.Key.Contains("$"))
                                                        {
                                                            successCheck(oLines, (int)oLines.InvokeMethod("nSetValue", lineEntry.Key, float.Parse(lineEntry.Value)), lineEntry.Key);
                                                        }
                                                        else
                                                        {
                                                            successCheck(oLines, (int)oLines.InvokeMethod("nSetValue", lineEntry.Key, lineEntry.Value), lineEntry.Key);
                                                        }
                                                    }
                                                }

                                                // Write each line object
                                                successCheck(oLines, (int)oLines.InvokeMethod("nWrite"), "LineWrite");
                                            }
                                        }
                                    }

                                    // Write the header object
                                    responseMessage = Sage100HeaderWriteSuccessCheck(headerObject, (int)headerObject.InvokeMethod("nWrite"), "HeaderWrite");

                                }
                            }
                        }
                    }
                }

                return responseMessage;
            }
            catch (Exception ex)
            {
                var responseMessage = "";
                ExceptionLogger.LogException(ex);
                return responseMessage;
            }
        }
    }
}
