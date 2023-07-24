using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorLibrary.Models
{
    class Sage100InsertModel
    {
        /// <summary>
        /// Method for checking if the Sage 100 insert is a sales order invoice or inventory transaction
        /// </summary>
        public static string InsertType { get; set; }
    }
}
