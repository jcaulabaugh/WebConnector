using ConnectorLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorLibrary.Utilities
{
    class PostDtoBuilder
    {
        public static PostDtoModel PostDto(string tableName, string userID, string requestStatus)
        {
                PostDtoModel Data = new PostDtoModel();

                string filePath = $@"{ GlobalConfig.filePath() }\{ tableName }.txt";

                if (File.Exists(filePath))
                {
                    var fileReader = File.ReadAllText(filePath);
                    Data.Xml = fileReader;
                    Data.Status = requestStatus;
                }

                Data.Token = userID;

                File.Delete(filePath);

                return Data;
        }

        public static PostDtoModel PostInsertDto(string userID, string requestStatus)
        {
            PostDtoModel Data = new PostDtoModel();

            Data.Status = requestStatus;
            Data.Token = userID;

            if (requestStatus == "True")
            {
                Data.Xml = "";
            }
            else
            {
                Data.Xml = requestStatus;
            }

            return Data;
        }

        public static PostDtoModel GenericPostInsertDto(string userID, string requestStatus)
        {
            PostDtoModel Data = new PostDtoModel();
            Data.Token = userID;

            Data.Xml = requestStatus;

            if (!string.IsNullOrEmpty(requestStatus))
            {
                
                Data.Status = "True";
            }
            else
            {
        
                Data.Status = "false";
            }

            return Data;
        }
    }
}
