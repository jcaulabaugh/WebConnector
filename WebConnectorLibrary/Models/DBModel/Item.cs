using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorLibrary.Models.DBModel
{
    [Table(Name = "IV00101")]
    public class Item
    {
        [Column]
        public decimal CURRCOST { get; set; }

        [Column]
        public short TAXOPTNS { get; set; }

 /*       [Column]
        public string LISTPRCE { get; set; }*/

        [Column]
        public byte INACTIVE { get; set; }

        [Column]
        public string ITEMNMBR { get; set; }

        [Column]
        public string ITEMDESC { get; set; }

        [Column]
        public string ITMSHNAM { get; set; }

        [Column]
        public string UOMSCHDL { get; set; }
    }
}
