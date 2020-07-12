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
        public static async Task<List<CustomerItem>> GetCustomers()
        {
            return await Task.Run(async () =>
            {

                using (var context = new NorthwindContext())
                {
                    return await context.Customers.AsNoTracking()
                        .Include(c => c.Contact)
                        .ThenInclude(xx => xx.ContactDevices)
                        .ThenInclude(xx => xx.PhoneTypeIdentifierNavigation)
                        .Include(c => c.ContactTypeIdentifierNavigation)
                        .Include(c => c.CountryIdentifierNavigation)
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
                                .FirstOrDefault(x => x.PhoneTypeIdentifier == 3).PhoneNumber
                        }).ToListAsync();


                }
            });
        }
    }
}
