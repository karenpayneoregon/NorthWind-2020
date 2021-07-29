using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Newtonsoft.Json;
using M = NorthWindCore.Models;
using NorthWindCore.Classes;

// ReSharper disable once CheckNamespace
namespace North.Models
{
    public class Customers
    {
        [NotMapped]
        [JsonIgnore]
        public string FirstName { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string LastName { get; set; }
        public static Expression<Func<M.Customers, CustomerEntity>> Projection => (customer) => new CustomerEntity()
            {
                CustomerIdentifier = customer.CustomerIdentifier,
                CompanyName = customer.CompanyName,
                Street = customer.Street,
                City = customer.City,
                PostalCode = customer.PostalCode,
                ContactTypeIdentifier = customer.ContactTypeIdentifier.Value,
                ContactTitle = customer.ContactTypeIdentifierNavigation.ContactTitle,
                ContactId = customer.ContactId,
                CountryName = customer.CountryIdentifierNavigation.Name,
                FirstName = customer.Contact.FirstName,
                LastName = customer.Contact.LastName,
                ContactIdentifier = Convert.ToInt32(customer.ContactId),
                Contacts = customer.Contact,
                CountryIdentifier = customer.CountryIdentifier,
                CountryNavigation = customer.CountryIdentifierNavigation,
                LastUpdated = customer.ModifiedDate
            };
    }
}
