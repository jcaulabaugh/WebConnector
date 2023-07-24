using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using Sage.Peachtree.API;
using Sage.Peachtree.API.Collections.Generic;
using ConnectorLibrary.DataProcess;
using ConnectorLibrary.Models;
using ConnectorLibrary.Utilities;
using MCNiWebServiceApp.Utilities;
using System.Configuration;

namespace ConnectorLibrary.DataAccess
{
    /// <summary>
    /// This class contains all logic for connecting to Sage 50
    /// </summary>
    public class Sage50Connector
    {

        /// <summary>
        /// Method for checking the SDK information provided by the user in the Sage50Config form. SDK connnection is required when inputting data into  Sage 50
        /// </summary>
        /// <param name="companyName"></param>
        public static void Sage50SDKConnectionTest(string companyName)
        {
            try
            {
                // If the method is succesful, the connectionTest status is set to True
                bool connectionTest = false;

                using (PeachtreeSession apiSession = new PeachtreeSession())
                {
                    // Request authorization from Sage 50 for our third-party application to access company.
                    apiSession.Begin(GlobalConfig.sage50AppID());

                    // Get CompanyIdentifer for the users provided company name
                    CompanyIdentifierList m_companyIdList = apiSession.CompanyList();

                    Exception e = new Exception(m_companyIdList.ToString());
                    ExceptionLogger.LogException(e);


                    CompanyIdentifier companyId = m_companyIdList.Find(
                    delegate (CompanyIdentifier o)
                    {
                        return o.CompanyName == companyName;
                    });

                    AuthorizationResult AuthResult = apiSession.RequestAccess(companyId);

                    // Ask the Sage 50 application if this application has been granted access to the company
                    AuthResult = apiSession.VerifyAccess(companyId);

                    // Check if the application has authorization
                    if (AuthResult == AuthorizationResult.Granted)
                    {
                        connectionTest = true;
                    }
                }

                if (connectionTest == true)
                {
                    // If the test  succeeds, set the SDK connection status to true
                    ConnectionTestModel.Sage50SDKConnectionStatus = true;
                }
            }
            catch (Exception e)
            {
                ExceptionLogger.LogException(e);
            }
        }

        /// <summary>
        /// Method for testing the users information provided in the Sage50Config form
        /// </summary>
        /// <param name="datasource"></param>
        /// <param name="password"></param>
        public static void Sage50DatasourceConnectionTest(string datasource, string password)
        {
            try
            {
                bool connectionTest = false;
                var connectionString = $@"DSN={ datasource }; UID=Peachtree; PWD={ password }";

                // Use an ODBC connection with the Sage 50 driver
                using (OdbcConnection cnn = new OdbcConnection(connectionString))
                {
                    cnn.Open();

                    if (cnn.State == ConnectionState.Open)
                    {
                        connectionTest = true;
                    }
                    else
                    {
                        connectionTest = false;
                    }
                }

                // If the test succeeds, set the connection status to true
                if (connectionTest == true)
                {

                    ConnectionTestModel.Sage50DatasourceConnectionStatus = true;
                }
            }
            catch (Exception e)
            {
                ExceptionLogger.LogException(e);
            }
        }

        /// <summary>
        /// Method for adding values to the XML response string. This is called if the requested table is Customers
        /// </summary>
        /// <param name="row"></param>
        /// <param name="rowAddition"></param>
        /// <param name="key"></param>
        public static void AddValues(Dictionary<string, object> row, Dictionary<string, object> rowAddition, string key)
        {
            object value;

            if (rowAddition.ContainsKey(key) && !row.ContainsKey(key))
            {
                value = rowAddition[key];

                row.Add(key, value);
            }
        }

        /// <summary>
        /// Method for reading data in a Sage 50 database
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <returns></returns>
        public string ReadSage50Table(Dictionary<string, string> tableInfo)
        {
            string tableName = tableInfo["Name"];
            string tableDate;

            // Set the sql query
            var SqlString = $"{ ConfigurationManager.AppSettings[Common.SAGE_COMMAND] } { tableName }";

            string jsonData = "";
            
            string connectionString = null;

            try
            {
                // Get the users information from the config file
                if (File.Exists(ConfigHelper.filePath))
                {
                    var doc = XDocument.Load(ConfigHelper.filePath);

                    if (doc.Descendants("Sage50").Any())
                    {
                        var datasource = doc.Element("Company").Element("Sage50").Element("Sage50_Datasource_Name").Value;
                        var password = doc.Element("Company").Element("Sage50").Element("Sage50_Datasource_Password").Value;

                        connectionString = $@"DSN={ datasource }; UID=Peachtree; PWD={ password }";

                        ActivityLog.activityListText($"Processing (Accounting Sync) { tableName }");
                    }
                }

                using (OdbcConnection cnn = new OdbcConnection(connectionString))
                {

                    OdbcCommand cmd = new OdbcCommand(SqlString, cnn);

                    cnn.Open();

                    OdbcDataReader reader = cmd.ExecuteReader();

                    var output = JSONGenerator.Serialize(reader);

                    // If the requested table is Customers, then additional address information is collected from the Address table and included in the XML response
                    if (tableName == "Customers")
                    {
                        SqlString = $"{ ConfigurationManager.AppSettings[Common.SAGE_COMMAND] } Address";

                        cmd = new OdbcCommand(SqlString, cnn);

                        reader = cmd.ExecuteReader();

                        var outputAddition = JSONGenerator.Serialize(reader);

                        foreach (var row in output)
                        {
                            foreach (var rowAddition in outputAddition)
                            {
                                if (row["CustomerRecordNumber"].ToString() == rowAddition["CustomerRecordNumber"].ToString())
                                {
                                    AddValues(row, rowAddition, "AddressLine1");
                                    AddValues(row, rowAddition, "City");
                                    AddValues(row, rowAddition, "State");
                                    AddValues(row, rowAddition, "Zip");
                                    AddValues(row, rowAddition, "TaxCode");
                                }
                            }
                        }
                    }



                   if (tableName == "LineItem")
                    {
                        SqlString = ConfigurationManager.AppSettings[Common.SAGE_50_QUANTITY];
                  /*      SqlString = @"SELECT I.ItemID
                        , I.ItemDescription
                        , C.RecordType
                        , C.TransDate
                        , C.PostOrderNumber
                        , C.Quantity
                        , C.TransAmount
                        FROM LineItem I JOIN InventoryCosts C
                        ON I.ItemRecordNumber = C.ItemRecNumber
                        INNER JOIN(
                        SELECT ItemRecNumber, RecordType, MAX(TransDate) AS lastDate, MAX(PostOrderNumber) AS LastEntry FROM InventoryCosts
                        WHERE TransDate< '2021-06-01' AND RecordType = 50
                        GROUP BY ItemRecNumber , RecordType) S
                        ON C.ItemRecNumber = S.ItemRecNumber AND C.RecordType = S.RecordType AND C.TransDate = S.lastDate--AND C.PostOrderNumber = S.LastEntry
                        WHERE(C.Quantity <> 0 OR C.TransAmount <> 0)
                        ORDER BY I.ITemID";*/

                        cmd = new OdbcCommand(SqlString, cnn);

                        reader = cmd.ExecuteReader();

                        var outputAddition = JSONGenerator.Serialize(reader);

                        foreach (var row in output)
                        {
                            foreach (var rowAddition in outputAddition)
                            {
                                if (row["ItemID"].ToString() == rowAddition["ItemID"].ToString())
                                {
                                    AddValues(row, rowAddition, "Quantity");
                                }
                            }
                        }
                    }

                    jsonData = JsonConvert.SerializeObject(output, Formatting.Indented);

                    // Save table data to json file using tableinfo(name of table)
                    jsonData.SaveToJSONFile(tableName);

                    // Convert JSON to xml to send back to server
                    Convertor.XMLConversion(tableName, "Sage50");

                    return "True";
                }
            }
            catch
            {
                return "false";
            }
        }

        private static void Sage50HeaderEntry(Dictionary<string, string> headerInfo, SalesInvoice salesInvoice)
        {
            // Header entry
            foreach (KeyValuePair<string, string> headerEntry in headerInfo)
            {
                if (!String.IsNullOrEmpty(headerEntry.Value))
                {
                    // Check if value expected by sage needs to be a string or float
                    if (!headerEntry.Key.Contains("$"))
                    {
                        var headerEntryKey = headerEntry.Key;

                        // Check if the property exists on the sales order invoice object
                        if (salesInvoice.GetType().GetProperty(headerEntryKey) != null)
                        {
                            var type = salesInvoice.GetType();
                            var property = type.GetProperty(headerEntryKey);

                            // Set the property on the sales order invoice
                            property.SetValue(salesInvoice, float.Parse(headerEntry.Value), new object[] { });
                        }
                    }
                    else
                    {
                        // Remove the $ from the xml
                        var headerEntryString = headerEntry.Key;
                        headerEntryString = headerEntryString.Remove(headerEntryString.Length - 1, 1);

                        // Check if the property exists on the sales order invoice object
                        if (salesInvoice.GetType().GetProperty(headerEntryString) != null && headerEntryString != "Date")
                        {

                            var type = salesInvoice.GetType();
                            var property = type.GetProperty(headerEntryString);

                            // Set the property on the sales order invoice
                            property.SetValue(salesInvoice, headerEntry.Value, new object[] { });
                        }
                        else
                        {
                            var type = salesInvoice.GetType();
                            var property = type.GetProperty(headerEntryString);

                            // Set the property on the sales order invoice
                            property.SetValue(salesInvoice, DateTime.Parse(headerEntry.Value), new object[] { });
                        }
                    }
                }
            }
        }

        private static void Sage50LineEntry(Company peachtreeCompany, List<Dictionary<string, string>> lineInfo, SalesInvoice salesInvoice, string responseMessage)
        {
            InventoryItem inventory = null;

            // lines entry, loop thorugh list of entries
            foreach (Dictionary<string, string> lineEntries in lineInfo)
            {
                SalesInvoiceSalesLine salesLine = salesInvoice.AddSalesLine();

                // line entry, loop through each entry
                foreach (KeyValuePair<string, string> lineEntry in lineEntries)
                {
                    if (!String.IsNullOrEmpty(lineEntry.Value))
                    {
                        // check if value expected by sage needs to be a string or float
                        if (!lineEntry.Key.Contains("$"))
                        {
                            var lineEntryKey = lineEntry.Key;
                            // Check if the property exists on the sales order invoice object
                            if (salesLine.GetType().GetProperty(lineEntryKey) != null)
                            {
                                var type = salesLine.GetType();
                                var property = type.GetProperty(lineEntryKey);

                                if (lineEntryKey == "SalesTaxType")
                                {
                                    // Set the property on the sales order invoice
                                    property.SetValue(salesLine, Int32.Parse(lineEntry.Value), new object[] { });
                                }
                                else
                                {
                                    // Set the property on the sales order invoice
                                    property.SetValue(salesLine, decimal.Parse(lineEntry.Value), new object[] { });
                                }
                            }
                        }
                        else
                        {
                            var lineEntryKey = lineEntry.Key;

                            // Remove the $ from the xml
                            lineEntryKey = lineEntryKey.Remove(lineEntryKey.Length - 1, 1);


                            if (lineEntryKey == "ItemID")
                            {
                                InventoryItemList itemList = peachtreeCompany.Factories.InventoryItemFactory.List();

                                //retval = olines.invokemethod("naddline");
                                FilterExpression expression = FilterExpression.Equal(
                                FilterExpression.Property("InventoryItem.ID"),
                                FilterExpression.Constant(lineEntry.Value));

                                LoadModifiers modifier = LoadModifiers.Create();
                                modifier.Filters = expression;
                                itemList.Load(modifier);

                                if (itemList.Count > 0)
                                {
                                    inventory = itemList[0];
                                }
                                else
                                {
                                    Exception validation = new Exception($"Item is invalid");
                                    ExceptionLogger.LogException(validation);
                                    responseMessage = "Error - Item is not valid";
                                }

                                // set line key
                                salesLine.InventoryItemReference = inventory.Key;
                                salesLine.Description = inventory.Description;
                            }
                            else
                            {
                                var type = salesLine.GetType();
                                var property = type.GetProperty(lineEntryKey);

                                // Set the property on the sales order invoice
                                property.SetValue(salesLine, lineEntry.Value, new object[] { });
                            }
                        }
                    }
                }

                if (!salesLine.Validate())
                {
                    Exception validation = new Exception($"{ lineInfo } is not valid");
                    ExceptionLogger.LogException(validation);
                }
            }
        }

        public static string sage50Processor(Dictionary<string, string> headerInfo, List<Dictionary<string, string>> lineInfo)
        {
            try
            {
                string responseMessage = "";
                var company = "";

                using (PeachtreeSession peachtreeSession = new PeachtreeSession())
                {

                    // the active Sage 50 Company
                    Company peachtreeCompany = null;

                    // Set the applicationID for access to Sage 50 Company
                    peachtreeSession.Begin(GlobalConfig.sage50AppID());
                  
                    if (File.Exists(ConfigHelper.filePath))
                    {
                        var doc = XDocument.Load(ConfigHelper.filePath);

                        if (doc.Descendants("Sage50").Any())
                        {
                             company = doc.Element("Company").Element("Sage50").Element("Sage50_Company").Value;
                        }

                        ActivityLog.activityListText($"Inputting Sage 50 Sales Order Invoice for company { company }");
                    }

                    // Get CompanyIdentifer for Bellwether Garden Supply sample company
                    CompanyIdentifierList m_companyIdList = peachtreeSession.CompanyList();
                    CompanyIdentifier companyId = m_companyIdList.Find(
                    delegate (CompanyIdentifier o)
                    {
                        return o.CompanyName == company;
                    });

                    AuthorizationResult AuthResult = peachtreeSession.RequestAccess(companyId);

                    // Ask the Sage 50 application if this application has
                    // been granted access to the company.
                    AuthResult = peachtreeSession.VerifyAccess(companyId);

                    // check if the app has authorization before
                    if (AuthResult == AuthorizationResult.Granted)
                    {
                        // open the company
                        peachtreeCompany = peachtreeSession.Open(companyId);
                    }

                    SalesInvoice salesInvoice = peachtreeCompany.Factories.SalesInvoiceFactory.Create();

                    EntityList<Customer> m_CustomerList = null;
                    EntityList<InventoryItem> m_InventoryList = null;

                    m_CustomerList = peachtreeCompany.Factories.CustomerFactory.List();
                    m_CustomerList.Load();

                    Customer customer = null;

                    // Get the customer ID from the header xml info
                    var CustomerId = headerInfo["CustomerNo$"];
                    headerInfo.Remove("CustomerNo$");

                    // Search through customer list in sage to match ID to customer name
                    foreach (Customer cust in m_CustomerList)
                    {
                        if (cust.ID == CustomerId)
                        {
                            customer = cust;

                            // Set the customer and key
                            salesInvoice.CustomerReference = customer.Key;
                        }
                    }

                    salesInvoice.ShipToAddress.Address.Address1 = customer.ShipToContact.Address.Address1;
                    salesInvoice.ShipToAddress.Address.City = customer.ShipToContact.Address.City;
                    salesInvoice.ShipToAddress.Address.State = customer.ShipToContact.Address.State;
                    salesInvoice.ShipToAddress.Address.Country = customer.ShipToContact.Address.Country;
                    salesInvoice.ShipToAddress.Address.Zip = customer.ShipToContact.Address.Zip;
                    salesInvoice.SalesRepresentativeReference = customer.SalesRepresentativeReference;
                    salesInvoice.SalesRepresentativeReference = customer.SalesRepresentativeReference;

                    SalesTaxCodeList codes = peachtreeCompany.Factories.SalesTaxCodeFactory.List();
                    codes.Load();
                    salesInvoice.SalesTaxCodeReference = codes[1].Key;

                    Sage50HeaderEntry(headerInfo, salesInvoice);
                    Sage50LineEntry(peachtreeCompany, lineInfo, salesInvoice, responseMessage);

                    if (!salesInvoice.Validate())
                    {
                        Exception validation = new Exception($"Invoice is not valid");
                        ExceptionLogger.LogException(validation);
                        responseMessage = "Error - Invoice is not valid";
                    }
                    else
                    {
                        responseMessage = "True";
                    }

                    salesInvoice.Save();
                    peachtreeSession.End();
                }

                return responseMessage;
            }
            catch (Sage.Peachtree.API.Exceptions.PeachtreeException ex)
            {
                ExceptionLogger.LogException(ex);
                ActivityLog.activityListText("Error Recorded. Check Log.");

                var responseMessage = "Error - Header did not write";
                return responseMessage;
            }
        }
    }
}
