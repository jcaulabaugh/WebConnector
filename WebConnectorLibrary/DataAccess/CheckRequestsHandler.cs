using System.Net.Http;
using System.Threading.Tasks;

namespace ConnectorLibrary.DataAccess
{
    public class CheckRequestsHandler
    {
        /// <summary>
        /// Method for getting the info that needs to be 
        /// processed from the queue
        /// </summary>
        /// <param name="client">the http client</param>
        /// <param name="authId">The users token</param>
        /// <returns></returns>
        public static async Task<string> CheckRequestsAsync(HttpClient client, string authId)
        {
            try
            {
                // Client response
                var res = await client.GetAsync("requestxml/" + authId);

                if (res.IsSuccessStatusCode)
                {
                    var response = await res.Content.ReadAsStringAsync();

                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
