using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NorthWindCore.Classes;

// ReSharper disable once CheckNamespace - must be this namespace
namespace North.Models
{
    public partial class Customers
    {
        [NotMapped]
        [JsonIgnore]
        public string FirstName { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string LastName { get; set; }
        public static Expression<Func<NorthWindCore.Models.Customers, CustomerEntity>> Projection
        {

            get
            {
                return (customer) => new CustomerEntity()
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


    }
}
