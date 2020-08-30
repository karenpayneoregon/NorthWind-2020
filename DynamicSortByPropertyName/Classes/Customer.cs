using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DynamicSortByPropertyName.Classes;
using NorthClassLibrary.Models;

namespace NorthClassLibrary.Models
{
    public partial class Customer
    {
        [NotMapped] public string FirstName { get; set; }
        [NotMapped] public string LastName { get; set; }

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
