using System;
using System.Linq;
using System.Linq.Expressions;
using NorthWindCore.Models;

namespace NorthWindCore.Classes.Projections
{
    public class CustomerItem
    {
        public int CustomerIdentifier { get; set; }
        public string CompanyName { get; set; }
        public int? ContactId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? CountryIdentifier { get; set; }
        public string Phone { get; set; }
        public int? ContactTypeIdentifier { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactName => $"{FirstName} {LastName}";
        public string ContactTitle { get; set; }
        public string OfficePhoneNumber { get; set; }
        public int PhoneTypeIdentifier { get; set; }
        public override string ToString() => CompanyName;

        public static Expression<Func<Customers, CustomerItem>> Projection =>
            (customers) => new CustomerItem()
            {
                CustomerIdentifier = customers.CustomerIdentifier,
                CompanyName = customers.CompanyName,
                ContactId = customers.ContactId,
                ContactTitle = customers.ContactTypeIdentifierNavigation.ContactTitle,
                FirstName = customers.Contact.FirstName,
                LastName = customers.Contact.LastName,
                CountryIdentifier = customers.CountryIdentifier,
                Country = customers.CountryIdentifierNavigation.Name,
                ContactTypeIdentifier = customers.CountryIdentifier,
                OfficePhoneNumber = customers.Contact.ContactDevices
                    .FirstOrDefault(contactDevices => contactDevices.PhoneTypeIdentifier == 3).PhoneNumber
            };
    }
}
