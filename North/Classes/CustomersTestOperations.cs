using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using North.Contexts;

namespace North.Classes
{
    public class CustomersTestOperations
    {
        public static async Task<List<CustomerItem>> GetCustomerItemsForComboBox()
        {
            return await Task.Run(async () =>
            {

                using (var context = new NorthwindContext())
                {
                    return await context.Customers.AsNoTracking()
                        .Select(customer => new CustomerItem()
                        {
                            CustomerIdentifier = customer.CustomerIdentifier,
                            CompanyName = customer.CompanyName,
                        }).ToListAsync();


                }
            });
        }
        /// <summary>
        /// Conventional loading of entities
        /// </summary>
        /// <returns></returns>
        public static async Task<List<CustomerItem>> GetCustomersAsync()
        {
            return await Task.Run(async () =>
            {

                using (var context = new NorthwindContext())
                {
                    return await context.Customers.AsNoTracking()
                        .Include(customer => customer.Contact)
                        .ThenInclude(contact => contact.ContactDevices)
                        .ThenInclude(contactDevices => contactDevices.PhoneTypeIdentifierNavigation)
                        .Include(customer => customer.ContactTypeIdentifierNavigation)
                        .Include(customer => customer.CountryIdentifierNavigation)
                        .Select(customer => new CustomerItem()
                        {
                            CustomerIdentifier = customer.CustomerIdentifier,
                            CompanyName = customer.CompanyName,
                            ContactId = customer.Contact.ContactId,
                            Street = customer.Street,
                            City = customer.City,
                            PostalCode = customer.PostalCode,
                            CountryIdentifier = customer.CountryIdentifier,
                            Phone = customer.Phone,
                            ContactTypeIdentifier = customer.ContactTypeIdentifier,
                            Country = customer.CountryIdentifierNavigation.Name,
                            FirstName = customer.Contact.FirstName,
                            LastName = customer.Contact.LastName,
                            ContactTitle = customer.ContactTypeIdentifierNavigation.ContactTitle,
                            OfficePhoneNumber = customer.Contact.ContactDevices
                                .FirstOrDefault(contactDevices => contactDevices.PhoneTypeIdentifier == 3).PhoneNumber
                        }).ToListAsync();


                }
            });
        }
        /// <summary>
        /// Example of using projections
        /// </summary>
        /// <returns></returns>
        public static async Task<List<CustomerItem>> GetCustomersWithProjectionAsync()
        {

            return await Task.Run(async () =>
            {

                using (var context = new NorthwindContext())
                {
                    return await context.Customers.AsNoTracking().Select(CustomerItem.Projection).ToListAsync();
                }

            });

        }

    }
}
