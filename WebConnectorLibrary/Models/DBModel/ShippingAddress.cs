using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorLibrary.Models.DBModel
{
    [Table(Name = "RM00102")]
    public class ShippingAddress
    {
        [Column]
        public string TAXSCHID { get; set; }

        [Column]
        public string CUSTNMBR { get; set; }

        [Column]
        public string ShipToName { get; set; }

        [Column]
        public string ADDRESS1 { get; set; }

        [Column]
        public string CITY { get; set; }

        [Column]
        public string STATE { get; set; }

        [Column]
        public string ZIP { get; set; }
    }
}
