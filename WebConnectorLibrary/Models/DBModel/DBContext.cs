using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConnectorLibrary.Models.DBModel.Customer;

namespace ConnectorLibrary.Models.DBModel
{
    public class DBContext : DataContext
    {
        // This is essentially the connection to your database. It handles generating SQL statements and
        // creating objects out of those SQL statements (if they are queries)'

        public Table<Customer> CustomerTable;

        public Table<Barcode> BarCodeTable;

        public Table<Item> ItemTable;

        public Table<ItemLocation> ItemLocationTable;

        public Table<ItemSecondList> ItemSecondListTable;

        public Table<Locations> LocationsTable;

        public Table<PriceLevel> PriceLevelTable;

        public Table<SalesRep> SalesRepTable;

        public Table<ShippingAddress> ShippingAddressTable;

        public Table<TaxCode> TaxCodeTable;

        public Table<TaxLine> TaxLineTable;

        public Table<TaxSchedule> TaxScheduleTable;

        public Table<UnitsOfMeasure> UnitsOfMeasureTable;

        public DBContext(string connection) : base(connection) { }
    }
}
