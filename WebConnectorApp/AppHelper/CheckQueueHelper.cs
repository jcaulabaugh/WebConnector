using System;
using System.Net.Http;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Threading.Tasks;
using ConnectorLibrary.DataProccess;
using MCNiWebServiceApp.Utilities;
using ConnectorLibrary.Utilities;
using ConnectorLibrary;
using ConnectorLibrary.DataAccess;
using ConnectorLibrary.DataProcess;
using ConnectorLibrary.Models;


namespace WebConnectorApp
{
    /// <summary>
    /// This class represents the main logic of the application
    /// </summary>
    public class CheckQueueHelper
    {
        private static HttpClient _httpClient = new HttpClient();

        public static async Task CheckQueueFlow()
        {
            try
            {
                var client = _httpClient;
                var user = await AuthenticationHandler.UserAuthenticationAsync(_httpClient, "username", "password");

                // The timer interval
                var interval = "";

                if (!object.ReferenceEquals(null, user))
                {
                    if (File.Exists(ConfigHelper.filePath))
                    {
                        var doc = XDocument.Load(ConfigHelper.filePath);
                        if (doc.Descendants("Run_Every_Minutes").Any())
                        {
                            interval = doc.Element("Company").Element("Run_Every_Minutes").Value;
                        }
                    }
                    if (user.Count == 0)
                    {
                        ActivityLog.activityListText($"Nothing in queue, waiting <{ interval }> minutes");
                        // Show notification for updates
                        WebConnectorContext.appIcon.BalloonTipText = "Nothing in queue";
                        WebConnectorContext.appIcon.ShowBalloonTip(20000);
                    }

                    // User must be authenticted with ID
                    if (user.Status && user.Count > 0)
                    {
                        var request = "";
                        var requestType = "";
                        var requestStatus = "";

                        // Show notification for updates
                        WebConnectorContext.appIcon.BalloonTipText = "Fetching Updates";
                        WebConnectorContext.appIcon.ShowBalloonTip(20000);

                        // Count represents the number of items in the queue
                        for (int i = 0; i < user.Count; i++)
                        {
                            // Check cue and recieve xml response
                            user.XmlResponse = await CheckRequestsHandler.CheckRequestsAsync(client, user.Data);

                            if (!String.IsNullOrEmpty(user.XmlResponse))
                            {
                                request = XmlParser.XMLStringFormatter(user.XmlResponse);

                                requestType = XmlParser.CheckRequestType(request);
                            }

                            if (!String.IsNullOrEmpty(requestType))
                            {
                                await ProcessRequest.requestProcessor(_httpClient, user.Data, requestType, request);
                            }

                            if (i + 1 == user.Count)
                            {
                                ActivityLog.activityListText($"Nothing remaining in queue, waiting <{ interval }> minutes");
                            }
                        }
                    }
                }
                else
                {
                    ActivityLog.activityListText("Check username and password");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                ActivityLog.activityListText("Error Recorded. Check Log.");
            }
        }
    }
}
