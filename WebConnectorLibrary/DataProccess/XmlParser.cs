using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Newtonsoft.Json;
using ConnectorLibrary.Models;
using ConnectorLibrary.Utilities;
using MCNiWebServiceApp.Utilities;

namespace ConnectorLibrary.DataProcess
{
    /// <summary>
    /// Contains all methods used to parse XML strings
    /// </summary>
    public class XmlParser
    {
        /// <summary>
        /// Method for checking the request type from the server
        /// </summary>
        /// <param name="xml">The xml string retrieved from the server</param>
        public static string CheckRequestType(string xml)
        {

            var requestType = "";

            if (xml.Contains("Generic"))
            {
                requestType = "Generic";
                return requestType;
            }

            if (xml.Contains("G_SalesOrderInvoiceHeaderInsert"))
            {
                requestType = "GenericInsert";
                return requestType;
            }

            if ((xml.Contains("MCNIXMLReq") || (xml.Contains("MCNIMSGPXMLReq"))))
            {
                requestType = "MSGP";
                return requestType;
            }

            if (xml.Contains("MCNISAGE100XMLReq"))
            {
                requestType = "Sage100";
                return requestType;
            }

            if (xml.Contains("MCNISAGE50XMLReq"))
            {
                requestType = "Sage50";
                return requestType;
            }

            if (xml.Contains("eConnect"))
            {
                requestType = "MSGPInsert";
                return requestType;
            }

            if (xml.Contains("SO_SalesOrderInvoiceHeaderInsert") || xml.Contains("IM_TransactionHeaderInsert"))
            {
                requestType = "Sage100Insert";
                return requestType;
            }

            if (xml.Contains("SalesOrderInvoiceHeaderInsert"))
            {
                requestType = "Sage50Insert";
                return requestType;
            }

            return requestType;
        }

        /// <summary>
        /// Method for formatting the eConnect xml string that is returned by the server
        /// </summary>
        /// <param name="data">the xml string</param>
        /// <returns></returns>
        public static string XMLStringFormatter(string data)
        {
            string result = "";

        
            result = data.Substring(1);
            result = result.TrimEnd(result[result.Length - 1]);


            result = result.Replace("\r\n", "")
                                .Replace("\r", "")
                                .Replace("\n", "")
                                .Replace("\t", "")
                                .Replace(@"\", "")
                                .Replace("\n", "");

         
            if (result.Contains("eConnect"))
            {

         /*       string test = result.Substring(1, result.Length - 2);*/

                var eConnectDocId = "";

                // Checking if eConnectDOCID has been specified by the user in the eConnect Settings form
                if (File.Exists(ConfigHelper.filePath))
                {
                    var doc = XDocument.Load(ConfigHelper.filePath);

                    if (doc.Descendants("eConnectDOCID").Any() && !string.IsNullOrEmpty(doc.Element("Company").Element("eConnectDOCID").Value))
                    {
                        eConnectDocId = doc.Element("Company").Element("eConnectDOCID").Value;

                        result = result.Replace("STDINV", eConnectDocId);
                    }
                }
            }

            else if (result.Contains("Node Identifier"))
            {
                return result.Substring(0, result.IndexOf("Node Identifier"));
            }
            else if (result.Contains("ITEMNMBR"))
            {
                return result.Substring(0, result.IndexOf("ITEMNMBR"));
            }

            return result;
        }

        /// <summary>
        /// Method for getting the invoice number from XML string
        /// </summary>
        /// <param name="xml">The xml string retreived form the server</param>
        /// <returns></returns>
        public static string getInvoiceNumber(string xml)
        {

            if (xml.Contains("SOPNUMBE"))
            {
                XDocument doc = XDocument.Parse(xml);

                var values = (from p in doc.Descendants("SOPNUMBE")
                              select p);

                var invoiceNum = values.First().Value;

                return invoiceNum;
            }

            return xml;
        }

        /// <summary>
        /// Method for getting table name from xml string
        /// </summary>
        /// <param name="nav">The PathNavigator</param>
        /// <param name="path">Xml nodes that lead to the name elment</param>
        /// <returns></returns>
        public static string getTableName(XPathNavigator nav, string path)
        {
            XPathNavigator node = nav.SelectSingleNode(path);
            node.MoveToFirstChild();

            return node.LocalName;
        }

        /// <summary>
        /// Method for getting date from xml string
        /// </summary>
        /// <param name="nav">The XPathnavigator</param>
        /// <param name="path">Xml nodes that lead to the date element</param>
        /// <returns></returns>
        public static string getTableDate(XPathNavigator nav, string path)
        {
            XPathNavigator node = nav.SelectSingleNode(path);
            node.MoveToFirstChild();
            node.MoveToFirstChild();

            return node.InnerXml;
        }

        /// <summary>
        /// Method for parsing the xml string returned by the server
        /// </summary>
        /// <param name="XmlTableRequest">the xml string</param>
        /// <returns></returns>
        /// 
        public static Dictionary<string, string> ParseRequestedTable(string path, string XmlTableRequest)
        {
            try
            {
                Dictionary<string, string> tableInfo = new Dictionary<string, string>();

              /*  var xml = JsonConvert.DeserializeObject<string>(XmlTableRequest);*/

                XDocument doc = XDocument.Parse(XmlTableRequest);
                XPathNavigator nav = doc.CreateNavigator();

                // Extract the table name
                XPathNavigator node = nav.SelectSingleNode(path);
                node.MoveToFirstChild();

                tableInfo.Add("Name", node.LocalName);

                if ((doc.Descendants("FromModifiedDate").Any()))
                {
                    node.MoveToFirstChild();
       

                    tableInfo.Add("Date", node.InnerXml);
                }
               
                /*
                               
                /*
                                if (requestType == "MSGP")
                                {
                                    path = "/MCNI_MSGP_XML/MCNIMSGPXMLReq";
                                    tableInfo.Add("Name", getTableName(nav, path));
                                    return tableInfo;
                                }

                                if (requestType == "Sage100")
                                {
                                    path = "/MCNI_SAGE100_XML/MCNISAGE100XMLReq";
                                    tableInfo.Add("Name", getTableName(nav, path));
                                    return tableInfo;
                                }

                                if (requestType == "Sage50")
                                {
                                    path = "/MCNI_SAGE50_XML/MCNISAGE50XMLReq";
                                    tableInfo.Add("Name", getTableName(nav, path));
                                    return tableInfo;
                                }*/

                return tableInfo;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static string ParseGenericRequest(string path, string xmlInfo)
        {
            var request = "";
            try
            {

                XDocument doc = XDocument.Parse(xmlInfo);



                if (doc.Descendants("MCNIGenericXMLReq").Any())
                {
                   

                XPathNavigator nav = doc.CreateNavigator();

                // Extract the table name
                XPathNavigator node = nav.SelectSingleNode(path);
                    var test = node.MoveToFirstChild();

                    request = node.LocalName;


                    /*request = doc.Element("MCNI_Generic_XML").Element("MCNIGenericXMLReq").Value;*/

                    /*        var values = (from p in doc.Descendants("MCNIGenericXMLReq")
                                          select p);

                            var invoiceNum = values.Last();*/


                

                    /*
                    node.MoveToFirstChild();

                    tableInfo.Add("Name", node.LocalName);

                    if ((doc.Descendants("FromModifiedDate").Any()))
                    {
                        node.MoveToFirstChild();


                        tableInfo.Add("Date", node.InnerXml);

                    }*/
                }

                    return request;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                return request;
            }
        }
    

         
        /// <summary>
        /// Method for parsing the Sage 100 header xml info
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static Dictionary<string, string> getHeaderInfo(string requestType, XElement xml)
        {
           
            try
            {
                var headerTag = "SalesOrderInvoiceHeaderInsert";

                if (requestType == "Sage50Insert")
                {
                    headerTag = "SalesOrderInvoiceHeaderInsert";
                }
                else if (requestType == "Sage100Insert")
                {
                    headerTag = "SO_SalesOrderInvoiceHeaderInsert";
                }
                else if (requestType == "GenericInsert")
                {
                    headerTag = "G_SalesOrderInvoiceHeaderInsert";
                }

                // Dictionaries to hold header and line info
                Dictionary<string, string> headerInfo = new Dictionary<string, string>();
                IEnumerable<XElement> headerInserts;

                // Info from xml nodes
                if (xml.Descendants(headerTag).Any())
                {
                    Sage100InsertModel.InsertType = "SO_Invoice";

                    headerInserts = xml.Descendants(headerTag).Descendants();
                }
                else
                {
                    Sage100InsertModel.InsertType = "IM_Transaction";
                    headerInserts = xml.Descendants("IM_TransactionHeaderInsert").Descendants();
                }

                foreach (var headerItem in headerInserts)
                {
                    if (headerItem.Name.LocalName.Contains("_"))
                    {
                        var formattedName = headerItem.Name.LocalName.Replace("_", "$");
                        headerInfo.Add(formattedName, headerItem.Value);
                    }
                    else
                    {
                        headerInfo.Add(headerItem.Name.LocalName, headerItem.Value);
                    }
                }

                return headerInfo;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Method for parsing the Sage 100 line info
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static List<Dictionary<string, string>> getLineInfo(string requestType, XElement xml)
        {
            try
            {
                var lineTag = "";

                if (requestType == "Sage50Insert")
                {
                    lineTag = "LinesInsert";
                }
                else if (requestType == "Sage100Insert" || requestType == "GenericInsert")
                {
                    lineTag = "oLinesInsert";
                }

                List<Dictionary<string, string>> lineInfo = new List<Dictionary<string, string>>();

                IEnumerable<XElement> lineInserts = xml.Descendants(lineTag).Elements();

                // Loop through and add each item to specific dictionary
                foreach (var lineItem in lineInserts)
                {
                    var lineDictionary = new Dictionary<string, string>();

                    foreach (var line in lineItem.Elements())
                    {
                        if (line.Name == "CommentText_" && line.Value.Contains("ORIG"))
                        {
                            line.Value = "";
                        }

                        if (line.Name.LocalName.Contains("_"))
                        {
                            var formattedName = line.Name.LocalName.Replace("_", "$");
                            lineDictionary.Add(formattedName, line.Value);
                        }
                        else
                        {
                            lineDictionary.Add(line.Name.LocalName, line.Value);
                        }
                    }

                    lineInfo.Add(lineDictionary);
                }

                return lineInfo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
