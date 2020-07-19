using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using North.Classes;

namespace North.Models
{
    public partial class Customers
    {
        [NotMapped]
        public string FirstName { get; set; }
        [NotMapped]
        public string LastName { get; set; }
        public static Expression<Func<Customers, CustomerEntity>> Projection
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
                    CountryName = customer.CountryIdentifierNavigation.Name,
                    FirstName = customer.Contact.FirstName,
                    LastName = customer.Contact.LastName,
                    ContactIdentifier = Convert.ToInt32(customer.ContactId),
                    CountryIdentifier = customer.CountryIdentifier
                };
            }

        }
    }
}
