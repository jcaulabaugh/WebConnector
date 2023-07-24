using ConnectorLibrary.DataProccess;
using MCNiWebServiceApp.Utilities;
using System;
using System.Net.Http;
using WebConnectorLibrary;
using WebConnectorLibrary.DataAccess;
using WebConnectorLibrary.DataProcess;
using WebConnectorLibrary.Models;
using System.Windows.Forms;

namespace ConnectorLibrary.Utilities
{
    /// <summary>
    /// This class represents the main logic of the application
    /// </summary>
    public class CheckQueueHelper
    {
        private static HttpClient _httpClient = new HttpClient();

        public static async void CheckQueueFlow()
        {
            var client = _httpClient;
            var user = await AuthenticationHandler.UserAuthenticationAsync(_httpClient, "username", "password");

            // User must be authenticted with ID
            if (user.Status)
            {
                // Count representes the number of items in the queue
                for (int i = 0; i < user.Count; i++)
                {
                   
                    try
                    {
                        // Check cue and recieve xml response
                        user.XmlResponse = await CheckRequestsHandler.CheckRequestsAsync(client, user.Data);
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogger.LogException(ex);
                    }
                    if (UserModel.Method != "eConnect")
                    {
                        // Parse xml file to get table name and date
                        TableInfoModel tableInfo = XmlParser.ParseRequestedTable(user.XmlResponse);

                        try
                        {
                            // Connect to the db and read the requested table, then searialize it as a json object
                            var data = SqlConnector.ReadTable(tableInfo);

                            // Save table data to json file using tableinfo(name of table)
                            data.SaveToJSONFile(tableInfo.Name);

                            // Convert JSON to xml to send back to server
                            Convertor.XMLConversion(tableInfo.Name);

                            // Send the file back to server
                            await SendDataHandler.DataSenderAsync(client, user.Data, tableInfo.Name);
                        }
                        catch (Exception ex)
                        {
                            ExceptionLogger.LogException(ex);
                        }
                    }
                    else
                    {
                        try
                        {
                            // Process an xml string that contains eConnect
                            user.XmlResponse = MSGPProcessor.MSGPFileProcessor(user.XmlResponse);
                        }
                        catch (Exception ex)
                        {
                            ExceptionLogger.LogException(ex);
                            user.XmlResponse = XmlParser.XMLStringFormatter(ex.Message);
                        }
                        try
                        {
                            // Send the result back to the server
                            await SendDataHandler.DataSenderAsync(client, user.Data, user.XmlResponse);
                        }
                        catch (Exception ex)
                        {
                            ExceptionLogger.LogException(ex);
                        }
                    }
                }
            }
        }
    }
}
