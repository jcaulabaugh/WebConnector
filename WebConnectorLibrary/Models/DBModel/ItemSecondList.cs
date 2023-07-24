using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorLibrary.Models.DBModel
{
    [Table(Name = "IV00105")]
    public class ItemSecondList
    {
        [Column]
        public decimal LISTPRCE { get; set; }

    }
}
