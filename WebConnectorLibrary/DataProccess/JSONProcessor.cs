using System.Configuration;
using System.IO;

namespace ConnectorLibrary.DataProcess
{
    public static class JSONProcessor
    {
        /// <summary>
        /// Method for returning the filepath
        /// </summary>
        /// <param name="filename">the name of the table</param>
        /// <returns></returns>
        public static string FullFilePath(this string filename)
        {
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ filename }";
        }

        /// <summary>
        /// Method for saving JSON file
        /// </summary>
        /// <param name="json"></param>
        /// <param name="fileName"></param>
        public static void SaveToJSONFile(this string json, string fileName)
        {
            File.WriteAllText($"{ fileName.FullFilePath() }.json", json);
        }
    }
}
