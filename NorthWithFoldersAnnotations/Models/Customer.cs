﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWithFoldersAnnotations.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        /// <summary>
        /// Id
        /// </summary>
        public int CustomerIdentifier { get; set; }
        [Required]
        [StringLength(40)]
        /// <summary>
        /// Company
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// ContactId
        /// </summary>
        public int? ContactId { get; set; }
        [StringLength(60)]
        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }
        [StringLength(15)]
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        [StringLength(15)]
        /// <summary>
        /// Region
        /// </summary>
        public string Region { get; set; }
        [StringLength(10)]
        /// <summary>
        /// Postal Code
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// CountryIdentifier
        /// </summary>
        public int? CountryIdentifier { get; set; }
        [StringLength(24)]
        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }
        [StringLength(24)]
        /// <summary>
        /// Fax
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// ContactTypeIdentifier
        /// </summary>
        public int? ContactTypeIdentifier { get; set; }
        /// <summary>
        /// Modified Date
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey(nameof(ContactId))]
        [InverseProperty("Customers")]
        public virtual Contact Contact { get; set; }
        [ForeignKey(nameof(ContactTypeIdentifier))]
        [InverseProperty(nameof(ContactType.Customers))]
        public virtual ContactType ContactTypeIdentifierNavigation { get; set; }
        [ForeignKey(nameof(CountryIdentifier))]
        [InverseProperty(nameof(Country.Customers))]
        public virtual Country CountryIdentifierNavigation { get; set; }
        [InverseProperty(nameof(Order.CustomerIdentifierNavigation))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}