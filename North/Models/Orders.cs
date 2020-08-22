
using System;
using System.Collections.Generic;
using North.Interfaces;

namespace North.Models
{
    public partial class Orders: IModelBaseEntity
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id => OrderID;
        public int OrderID { get; set; }
        public int? CustomerIdentifier { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public virtual Customers CustomerIdentifierNavigation { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual Shippers ShipViaNavigation { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

    }
}