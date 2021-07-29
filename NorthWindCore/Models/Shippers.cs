﻿using System.Collections.Generic;
using NorthWindCore.Interfaces;

namespace NorthWindCore.Models
{
    public partial class Shippers: IModelBaseEntity
    {
        public Shippers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id => ShipperID;
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}