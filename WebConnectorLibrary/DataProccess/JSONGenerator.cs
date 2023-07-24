using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace ConnectorLibrary.DataProcess
{
    public class JSONGenerator
    {
        /// <summary>
        /// Method for creating a JSON file
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static IEnumerable<Dictionary<string, object>> Serialize(SqlDataReader reader)
        {

            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();

            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRow(cols, reader));

            return results;
        }

        public static IEnumerable<Dictionary<string, object>> Serialize(OdbcDataReader reader)
        {

            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();

            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRow(cols, reader));

            return results;
        }

        private static Dictionary<string, object> SerializeRow(IEnumerable<string> cols, SqlDataReader reader)
        {
            var result = new Dictionary<string, object>();
            foreach (var col in cols)
            {
                // Checking string to remove the extra whitespace from char(50)
                if (reader[col].GetType() == typeof(string))
                {
                    result.Add(col, reader[col].ToString().Trim());
                }
                else
                {
                    result.Add(col, reader[col]);
                }
            }

            return result;
        }

        private static Dictionary<string, object> SerializeRow(IEnumerable<string> cols, OdbcDataReader reader)
        {
            var result = new Dictionary<string, object>();


            foreach (var col in cols)
            {
                // Checking string to remove the extra whitespace from char(50)
                if (reader[col].GetType() == typeof(string))
                {
                    result.Add(col, reader[col].ToString().Trim());
                }
                else
                {
                    result.Add(col, reader[col]);
                }
            }

            return result;
        }
    }
}
