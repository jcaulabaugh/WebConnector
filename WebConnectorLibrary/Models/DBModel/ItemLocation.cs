using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorLibrary.Models.DBModel
{
    // Table you want to associate with the entity
    [Table(Name = "IV00102")]
    public class ItemLocation
    {
        // Columns in the database. Should have the same name between database and class variable
        [Column]
        public string ITEMNMBR { get; set; }

        [Column]
        public string LOCNCODE { get; set; }

        [Column]
        public decimal QTYONHND { get; set; }

        [Column]
        public decimal ATYALLOC { get; set; }
    }
    
}
