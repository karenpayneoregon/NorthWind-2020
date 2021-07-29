﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NorthWindCore.Interfaces;
using NorthWindCore.Models;

namespace North.Models
{
    public partial class Countries : IModelBaseEntity
    {
        public Countries()
        {
            Customers = new HashSet<NorthWindCore.Models.Customers>();
            Employees = new HashSet<Employees>();
            Suppliers = new HashSet<Suppliers>();
        }

        public int Id => CountryIdentifier;
        public int CountryIdentifier { get; set; }
        public string Name { get; set; }

        public override string ToString() => Name;

        [JsonIgnore]
        public virtual ICollection<NorthWindCore.Models.Customers> Customers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employees> Employees { get; set; }
        [JsonIgnore]
        public virtual ICollection<Suppliers> Suppliers { get; set; }
    }
}