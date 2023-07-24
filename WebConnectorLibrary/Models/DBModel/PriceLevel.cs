using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorLibrary.Models.DBModel
{
    [Table(Name = "IV00108")]
    public class PriceLevel
    {
        [Column]
        public string PRCLEVEL { get; set; }

        [Column]
        public string ITEMNMBR { get; set; }

        [Column]
        public decimal UOMPRICE { get; set; }


    }
}
