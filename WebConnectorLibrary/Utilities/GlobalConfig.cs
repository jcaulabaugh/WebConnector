using System.Configuration;

namespace ConnectorLibrary.Utilities
{
    public class GlobalConfig
    {
        /// <summary>
        /// Returns the connection string for the app.config file
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string filePath()
        {
            return ConfigurationManager.AppSettings["FilePath"];
        }

        public static string fileName()
        {
            return ConfigurationManager.AppSettings["FileName"];
        }

        public static string sage50AppID()
        {
            return ConfigurationManager.AppSettings["AppID"];
        }
    }
}
