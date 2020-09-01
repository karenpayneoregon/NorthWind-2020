using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using NorthClassLibrary.Models;

namespace UtilityTestProject.Classes
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
                CompanyName = customer.CompanyName,
                CountryName = customer.CountryIdentifierNavigation.Name,
                FirstName = customer.Contact.FirstName,
                LastName = customer.Contact.LastName
            };
    }
}
