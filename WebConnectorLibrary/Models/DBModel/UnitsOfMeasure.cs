using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorLibrary.Models.DBModel
{
    [Table(Name = "IV40202")]
    public class UnitsOfMeasure
    {
        [Column]
        public decimal EQUOMQTY { get; set; }

        [Column]
        public string UOMSCHDL { get; set; }

        [Column]
        public string UOFM { get; set; }
    }
}
