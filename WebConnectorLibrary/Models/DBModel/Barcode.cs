using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace ConnectorLibrary.Models.DBModel
{
    [Table(Name = "SY01200")]
    public class Barcode
    {
        [Column]
        public string MASTER_ID { get; set; }

        [Column]
        public string INETINFO { get; set; }
    }
}
