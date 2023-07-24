using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorLibrary.Models.DBModel
{
    [Table(Name = "TX00101")]
    public class TaxSchedule
    {
        [Column]
        public string TAXSCHID { get; set; }

   /*     [Column]
        public decimal TAXDTLID { get; set; }*/
    }
}
