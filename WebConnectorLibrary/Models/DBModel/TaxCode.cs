using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorLibrary.Models.DBModel
{
    [Table(Name = "TX00201")]
    public class TaxCode
    {
        [Column]
        public string TAXDTLID { get; set; }

        [Column]
        public decimal TXDTLPCT { get; set; }
    }
}
