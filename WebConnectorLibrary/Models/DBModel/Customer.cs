using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorLibrary.Models.DBModel
{
    // Table you want to associate with the entity
    [Table(Name = "RM00101")]
    public class Customer
    {
        // Columns in the database. Should have the same name between database and class variable
        [Column(IsPrimaryKey = true)]
        public string CUSTNMBR { get; set; }

        [Column]
        public string CUSTNAME { get; set; }

        [Column]
        public byte INACTIVE { get; set; }

        [Column]
        public string ADDRESS1 { get; set; }

        [Column]
        public string CITY { get; set; }

        [Column]
        public string STATE { get; set; }

        [Column]
        public string ZIP { get; set; }

        [Column]
        public string BNKBRNCH { get; set; }

        [Column]
        public string PHONE1 { get; set; }

        [Column]
        public string PYMTRMID { get; set; }

        [Column]
        public string SLPRSNID { get; set; }

        [Column]
        public string TAXEXMT1 { get; set; }

        [Column]
        public string PRCLEVEL { get; set; }

        [Column]
        public byte HOLD { get; set; }

        [Column]
        public string TAXSCHID { get; set; }

        [Column]
        public string COMMENT2 { get; set; }

        [Column]
        public System.DateTime DEX_ROW_TS { get; set; }


    }
}
