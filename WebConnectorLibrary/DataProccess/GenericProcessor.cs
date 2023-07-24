using ConnectorLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConnectorLibrary.DataProccess
{
    public class GenericProcessor
    {
        /// <summary>
        /// Method for fomatting the header and line data with correct decimal places
        /// </summary>
        /// <param name="value">The value which needs to be checked for proper decimal</param>
        /// <returns>The formatted value</returns>
        public static string genericDecimalCheck(string value)
        {
            try
            {
                if (!value.Contains("."))
                {
                    value = value + ".00";
                }

                var decimalCheck = value.IndexOf(".");

                if (value.Substring(decimalCheck).Length < 3)
                {
                    value = value + "0";
                }

                return value;
            }
            catch
            {
                throw;
            }
            
        }

        /// <summary>
        /// Method for formatting the header data as per spec
        /// </summary>
        /// <param name="headerInfo">header data formatted as key - value pairs</param>
        /// <returns>The formatted header data</returns>
        public static Dictionary<string, string> headerDataProcessor(Dictionary<string, string> headerInfo)
        {
            try
            {
                while (headerInfo["OrderNo"].Length < 10)
                {
                    headerInfo["OrderNo"] = "0" + headerInfo["OrderNo"];
                }

                headerInfo["OrderDate"] = headerInfo["OrderDate"].Trim('/');

                while (headerInfo["OrderDate"].Length < 33)
                {
                    headerInfo["OrderDate"] = headerInfo["OrderDate"] + " ";
                }

                while (headerInfo["CustomerNo"].Length < 30)
                {
                    headerInfo["CustomerNo"] = headerInfo["CustomerNo"] + " ";
                }

                while (headerInfo["SalesRep"].Length < 30)
                {
                    headerInfo["SalesRep"] = headerInfo["SalesRep"] + " ";
                }

                headerInfo["TotalSale"] = genericDecimalCheck(headerInfo["TotalSale"]);

                while (headerInfo["TotalSale"].Length < 10)
                {
                    headerInfo["TotalSale"] = "0" + headerInfo["TotalSale"];
                }

                headerInfo["Taxes"] = genericDecimalCheck(headerInfo["Taxes"]);

                while (headerInfo["Taxes"].Length < 10)
                {
                    headerInfo["Taxes"] = "0" + headerInfo["Taxes"];
                }

                headerInfo["Payment"] = genericDecimalCheck(headerInfo["Payment"]);

                while (headerInfo["Payment"].Length < 10)
                {
                    headerInfo["Payment"] = "0" + headerInfo["Payment"];
                }

                return headerInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Method for formatting the line data as per spec
        /// </summary>
        /// <param name="lineInfo">Line info split into a list of key - value pairs</param>
        /// <returns>The formatted line data</returns>
        public static List<Dictionary<string, string>> lineDataProcessor(List<Dictionary<string, string>> lineInfo)
        {
            try
            {
                foreach (Dictionary<string, string> lineEntries in lineInfo)
                {
                    while (lineEntries["Sequence"].Length < 3)
                    {
                        lineEntries["Sequence"] = "0" + lineEntries["Sequence"];
                    }

                    while (lineEntries["ItemNo"].Length < 20)
                    {
                        lineEntries["ItemNo"] = lineEntries["ItemNo"] + " ";
                    }

                    while (lineEntries["Description"].Length < 50)
                    {
                        lineEntries["Description"] = lineEntries["Description"] + " ";
                    }

                    lineEntries["Price"] = genericDecimalCheck(lineEntries["Price"]);

                    while (lineEntries["Price"].Length < 10)
                    {
                        lineEntries["Price"] = "0" + lineEntries["Price"];
                    }

                    lineEntries["QuantityOrdered"] = lineEntries["QuantityOrdered"] + ".0";

                    while (lineEntries["QuantityOrdered"].Length < 7)
                    {
                        lineEntries["QuantityOrdered"] = "0" + lineEntries["QuantityOrdered"];
                    }

                    lineEntries["UOM"] = "EA";
                }
            }
            catch
            {
                throw;
            }
            

            return lineInfo;
        }

        /// <summary>
        /// Method for inputting the xml request into the dat files
        /// </summary>
        /// <param name="headerInfo">Header Info from the xml request</param>
        /// <param name="lineInfo">Line info from the xml request</param>
        /// <returns>Status of the data iinput</returns>
        public static string GenericDataProcessor(Dictionary<string, string> headerInfo, List<Dictionary<string, string>> lineInfo)
        {
            try
            {
                var responseMessage = "";
                var currentDateTime = DateTime.Now;
                var currentDate = currentDateTime.ToString("yyyyMMdd");

                var path = ConfigurationManager.AppSettings[Common.GENERIC_FILE_PATH];

                var dir = new DirectoryInfo(path);

                // If  directory  exist
                if (!dir.Exists)
                    dir.Create();

                // set current directory path
                Directory.SetCurrentDirectory(path);

                // set the file path
                var dataFilePath = (path + (@"\POSHEADERS_" + currentDate + ".dat"));

                // If file does not  exist
                if (!File.Exists(dataFilePath))
                    File.Create(dataFilePath).Close();

                var constant = "A";
                while (constant.Length < 131)
                {
                    constant = " " + constant;
                }

                using (var sw = File.AppendText(dataFilePath))
                {
                    sw.WriteLine($"{headerInfo["OrderNo"] + headerInfo["OrderType"] + headerInfo["OrderDate"] + headerInfo["CustomerNo"] + headerInfo["SalesRep"] + headerInfo["TotalSale"] + headerInfo["Taxes"] + headerInfo["Payment"] + constant}");
                    /*sw.WriteLine("0000000001I20200208                         403861                        PDA1                          0000004.000000000.000000000.00                                                                                                                                  A");*/
                }

                dataFilePath = (path + (@"\POSLINES_" + currentDate + ".dat"));
                // If file does not  exist
                if (!File.Exists(dataFilePath))
                    File.Create(dataFilePath).Close();

                using (var sw = File.AppendText(dataFilePath))
                {
                    foreach (Dictionary<string, string> lineEntries in lineInfo)
                    {
                        sw.WriteLine($"{headerInfo["OrderNo"] + lineEntries["Sequence"] + lineEntries["ItemNo"] + lineEntries["Description"] + headerInfo["SalesRep"].Substring(0, 10) + lineEntries["Price"] + lineEntries["QuantityOrdered"] + lineEntries["Taxed"] + lineEntries["UOM"]}");
                    }
                }

                ActivityLog.activityListText($"Saving Invoice {headerInfo["OrderNo"]}.");

                responseMessage = "True";
                return responseMessage;
            }
            catch
            {
                throw;

                var responseMessage = "Error - Header did not write";
                return responseMessage;
            } 
        }
    }
}
