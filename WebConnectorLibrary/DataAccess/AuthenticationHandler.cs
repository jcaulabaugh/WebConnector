using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using ConnectorLibrary.Models;
using ConnectorLibrary.Utilities;
using MCNiWebServiceApp.Utilities;



namespace ConnectorLibrary.DataAccess
{
    public class AuthenticationHandler
    {
        /// <summary>
        /// Method for authenticating the user and checking 
        /// the count of tables that need to be updated
        /// </summary>
        /// <param name="client">the http client instance</param>
        /// <returns></returns>
        public static async Task<GetDtoModel> UserAuthenticationAsync(HttpClient client, string username, string password)
        {
            // List for storing user information
            List<string> accountInfo = new List<string>();

            // Dictionary for storing username and password
            Dictionary<string, string> userInfo = new Dictionary<string, string>();

            // Check if username and password exist in the config file
            if (File.Exists(ConfigHelper.filePath))
            {
                var doc = XDocument.Load(ConfigHelper.filePath);

                if (doc.Descendants("MCNI_Username").Any() && doc.Descendants("MCNI_Password").Any() && doc.Descendants("Server").Any())
                {
                    username = doc.Element("Company").Element("MCNI_Username").Value;
                    password = doc.Element("Company").Element("MCNI_Password").Value;

                    ActivityLog.activityListText($"Sending username: { username } password: { new string('*', password.Length)  }");
                }

                if (client.BaseAddress == null)
                {
                    client.BaseAddress = new Uri(doc.Element("Company").Element("Server").Value);
                }
            }

            // Add credentials to the dictionary
            userInfo.Add("Username", username);
            userInfo.Add("Password", password);
            var content = new FormUrlEncodedContent(userInfo);

            try
            {
                // Client response
                var response = await client.PostAsync("Authenticate", content);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    // User response object
                    GetDtoModel responseObj = JsonConvert.DeserializeObject<GetDtoModel>(apiResponse);

                    // Store actions in activity list
                    if (!responseObj.Status)
                    {
                        ActivityLog.activityListText("Authentication Failed! Re-enter username and password");
                    }
                    else
                    {
                        ActivityLog.activityListText("Authenticated! Status = 250");
                    }

                    return responseObj;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
            }

            return null;
        }
    }
}
