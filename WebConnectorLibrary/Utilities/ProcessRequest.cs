using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConnectorLibrary.DataAccess;
using ConnectorLibrary.DataProcess;
using System.Configuration;
using MCNiWebServiceApp.Utilities;
using System;
using static ConnectorLibrary.Utilities.Common;
using ConnectorLibrary.DataProccess;

namespace ConnectorLibrary.Utilities
{
    public class ProcessRequest
    {

        public static async Task requestProcessor(HttpClient client, string userID, string requestType, string request)
        {
            try
            {
                Enum.TryParse(requestType, out RequestType requestTypeCheck);

                switch (requestTypeCheck)
                {
                    case RequestType.Sage50:
                        {
                            var tableInfo = XmlParser.ParseRequestedTable(ConfigurationManager.AppSettings[Common.SAGE_50], request);

                            Sage50Connector Sage50 = new Sage50Connector();
                            var status = Sage50.ReadSage50Table(tableInfo);

                            var dto = PostDtoBuilder.PostDto(tableInfo["Name"], userID, status);

                            // Send the file back to server
                            await SendDataHandler.DataSenderAsync(client, dto);
                            break;
                        }
                    case RequestType.Sage100:
                        {
                            var tableInfo = XmlParser.ParseRequestedTable(ConfigurationManager.AppSettings[Common.SAGE_100], request);

                            Sage100Connector Sage100 = new Sage100Connector();
                            var status = Sage100.ReadSage100Table(tableInfo);

                            var dto = PostDtoBuilder.PostDto(tableInfo["Name"], userID, status);

                            // Send the file back to server
                            await SendDataHandler.DataSenderAsync(client, dto);
                            break;
                        }
                    case RequestType.MSGP:
                        {
                            var tableInfo = XmlParser.ParseRequestedTable(ConfigurationManager.AppSettings[Common.MSGP], request);

                            MSGPConnector MSGP = new MSGPConnector();
                            var status = MSGPConnector.ReadMSGPTable(tableInfo);

                            var dto = PostDtoBuilder.PostDto(tableInfo["Name"], userID, status);

                            // Send the file back to server
                            await SendDataHandler.DataSenderAsync(client, dto);
                            break;
                        }
                    case RequestType.Sage50Insert:
                        {
                            // Get header and line info from the xml string
                            XElement sageXml = XElement.Parse(request);
                            var headerInfo = XmlParser.getHeaderInfo(requestType, sageXml);
                            var lineInfo = XmlParser.getLineInfo(requestType, sageXml);

                            // Connect to Sage 100 and input the data
                            var status = Sage50Connector.sage50Processor(headerInfo, lineInfo);

                            var dto = PostDtoBuilder.PostInsertDto(userID, status);

                            // Send the result back to the server
                            await SendDataHandler.DataSenderAsync(client, dto);
                            break;
                        }
                    case RequestType.Sage100Insert:
                        {
                            // Get header and line info from the xml string
                            XElement sageXml = XElement.Parse(request);

                            var headerInfo = XmlParser.getHeaderInfo(requestType, sageXml);
                            var lineInfo = XmlParser.getLineInfo(requestType, sageXml);

                            // Connect to Sage 100 and input the data
                            var status = Sage100Connector.sage100Processor(headerInfo, lineInfo);

                            var dto = PostDtoBuilder.PostInsertDto(userID, status);

                            // Send the result back to the server
                            await SendDataHandler.DataSenderAsync(client, dto);
                            break;
                        }
                    case RequestType.MSGPInsert:
                        {
                            // Process to MSGP and input the data
                            var status = MSGPConnector.MSGPFileProcessor(request);
                        
                            var dto = PostDtoBuilder.PostInsertDto(userID, status);

                            // Send the result back to the server
                            await SendDataHandler.DataSenderAsync(client, dto);
                            break;
                        }
                    case RequestType.Generic:
                        {
                            var requestInfo = XmlParser.ParseGenericRequest(ConfigurationManager.AppSettings[Common.GENERIC], request);
               
                            var status = GenericConnector.GenericDataConnector(requestInfo);

                            var dto = PostDtoBuilder.GenericPostInsertDto(userID, status);

                            // Send the result back to the server
                            await SendDataHandler.DataSenderAsync(client, dto);
                            break;
                        }
                    case RequestType.GenericInsert:
                        {
                            // Get header and line info from the xml string
                            XElement genericXml = XElement.Parse(request);

                            var headerInfo = XmlParser.getHeaderInfo(requestType, genericXml);
                            var lineInfo = XmlParser.getLineInfo(requestType, genericXml);

                            var processedHeaderInfo = GenericProcessor.headerDataProcessor(headerInfo);

                            var processedLineInfo = GenericProcessor.lineDataProcessor(lineInfo);

                            var status = GenericProcessor.GenericDataProcessor(processedHeaderInfo, lineInfo);

                            var dto = PostDtoBuilder.GenericPostInsertDto(userID, status);

                            // Send the result back to the server
                            await SendDataHandler.DataSenderAsync(client, dto);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
            }
            
        }
    }
}
