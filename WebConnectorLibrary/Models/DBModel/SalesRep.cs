using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorLibrary.Models.DBModel
{
    [Table(Name = "RM00301")]
    public class SalesRep
    {
        [Column]
        public string SLPRSNID { get; set; }

        [Column]
        public string SLPRSNFN { get; set; }
    }
}
