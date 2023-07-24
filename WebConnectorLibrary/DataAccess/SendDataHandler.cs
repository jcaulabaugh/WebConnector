using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConnectorLibrary.Models;
using ConnectorLibrary.Utilities;
using Newtonsoft.Json;

namespace ConnectorLibrary.DataAccess
{
    public class SendDataHandler
    {
        /// <summary>
        /// Method for sending the result back to us
        /// the server, after it has been processed 
        /// </summary>
        /// <param name="client">the http client</param>
        /// <param name="ID">the user token</param>
        /// <param name="data">xml string</param>
        /// <returns></returns>
        public static async Task DataSenderAsync(HttpClient client, PostDtoModel dataObject)
        {
            try
            {
                ActivityLog.activityListText($"Replying { dataObject.Status } to server");

                var content = JsonConvert.SerializeObject(dataObject);

                var receiveContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("ReceiveXml", receiveContent);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    // Call timeStamp to record last run time
                    ConfigHelper.TimeStamp();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

