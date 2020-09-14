using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using NorthClassLibrary.Models;

namespace NorthClassLibrary.Classes
{
    public class Customer
    {
        [NotMapped] public string FirstName { get; set; }
        [NotMapped] public string LastName { get; set; }
        /// <summary>
        /// Project for CustomerItem from Customers
        /// </summary>
        public static Expression<Func<Customers, CustomerItem>> Projection =>
            (customer) => new CustomerItem()
            {
                CustomerIdentifier = customer.CustomerIdentifier,
                ContactId = customer.ContactId,
                CompanyName = customer.CompanyName,
                CountryName = customer.CountryIdentifierNavigation.Name,
                FirstName = customer.Contact.FirstName,
                LastName = customer.Contact.LastName
            };
    }
}
