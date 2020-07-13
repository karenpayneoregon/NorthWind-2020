using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace North.Classes
{
    public class OrderItem
    {
        public int OrderID { get; set; }
        public int? CustomerIdentifier { get; set; }
        public int? EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public string ShipperName { get; set; }
        public decimal? Freight { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public override string ToString() => OrderID.ToString();

    }
}
