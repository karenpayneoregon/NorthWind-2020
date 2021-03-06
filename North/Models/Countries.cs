﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using North.Interfaces;

namespace North.Models
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

        public override string ToString() => Name;


        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Suppliers> Suppliers { get; set; }
    }
}