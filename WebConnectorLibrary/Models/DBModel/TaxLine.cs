using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorLibrary.Models.DBModel
{
    [Table(Name = "TX00102")]
    public class TaxLine
    {
        [Column]
        public string TAXSCHID { get; set; }

        [Column]
        public string TAXDTLID { get; set; }
    }
}
