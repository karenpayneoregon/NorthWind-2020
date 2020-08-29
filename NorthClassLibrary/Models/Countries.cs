﻿using System.Collections.Generic;
using North.Interfaces;

namespace NorthClassLibrary.Models
{
    public partial class Countries : IModelBaseEntity
    {
        public Countries()
        {
            Customers = new HashSet<Customers>();
            Employees = new HashSet<Employees>();
            Suppliers = new HashSet<Suppliers>();
        }

        public int Id => CountryIdentifier;
        public int CountryIdentifier { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Suppliers> Suppliers { get; set; }
    }
}