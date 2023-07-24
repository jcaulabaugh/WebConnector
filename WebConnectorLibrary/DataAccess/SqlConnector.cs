using ConnectorLibrary.Utilities;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using ConnectorLibrary.DataProcess;
using ConnectorLibrary.Models;
using ConnectorLibrary.Utilities;

namespace ConnectorLibrary.DataAccess
{
    public class SqlConnector
    {
        /// <summary>
        /// Method for connecting to the database
        /// to retrieve the requested table
        /// </summary>
        /// <param name="tableInfo">Model containing the table name and date</param>
        /// <returns></returns>
        public static string ReadTable(TableInfoModel tableInfo)
        {
            // Connecting to db
            SqlCommand command;
            SqlDataReader dataReader;
            var SqlString = "";
            string tableName = tableInfo.Name;
            string date = tableInfo.Date;

            // TODO - use sql parameters instead
            if (date != null)
            {
                SqlString = $"SELECT TOP 20000 * FROM { tableName } WHERE DEX_ROW_TS >= { date }";
            }
            else
            {
                SqlString = $"SELECT TOP 20000 * FROM { tableName }";
            }

            try
            {
                // Connectionstring
                string conn = "";

                if (File.Exists(GlobalConfig.fileName()))
                {
                    var doc = XDocument.Load(GlobalConfig.fileName());
   
                    if (doc.Descendants("ConnectionString").Any())
                    {
                        conn = doc.Element("Company").Element("ConnectionString").Value;
                    }
                }

                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    command = new SqlCommand(SqlString, connection);
                    dataReader = command.ExecuteReader();
                    var output = JSONGenerator.Serialize(dataReader);

                    dataReader.Close();

                    string jsonData = JsonConvert.SerializeObject(output, Formatting.Indented);
                    return jsonData;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
