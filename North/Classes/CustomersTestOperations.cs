﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using North.Classes.Helpers;
using North.Classes.Projections;
using North.Contexts;
using North.Models;

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

        public static async Task<List<string>> CustomerNames()
        {
            return await Task.Run(async () =>
            {
                using (var context = new NorthwindContext())
                {
                    return await context.Customers.OrderBy(cust => cust.CompanyName).Select(customer => customer.CompanyName).ToListAsync();
                }
            });
        }

        /// <summary>
        /// Conventional loading of entities
        /// </summary>
        /// <returns></returns>
        public static async Task<List<CustomerItem>> GetCustomersAsync()
        {

            var currentExecutable = Process.GetCurrentProcess().MainModule.FileName;
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
                            OfficePhoneNumber = customer.Contact.ContactDevices.FirstOrDefault(contactDevices => 
                                contactDevices.PhoneTypeIdentifier == 3).PhoneNumber
                        })
                        .TagWith($"App name: {currentExecutable}")
                        .TagWith($"From: {nameof(CustomersTestOperations)}.{nameof(GetCustomersAsync)}")
                        .TagWith("Parameters: None")
                        .ToListAsync();


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

        public static NorthwindContext Context = new NorthwindContext();
        /// <summary>
        /// Get customer data including contact for editing
        /// </summary>
        /// <returns></returns>
        public static async Task<List<CustomerEntity>> AllCustomersForDataGridViewAsync()
        {

            return await Task.Run(async () =>
            {
                List<CustomerEntity> customerItemsList = await Context.Customers
                    .Include(customer => customer.Contact)
                    .Select(Customers.Projection)
                    .ToListAsync();

                return customerItemsList.OrderBy((customer) => customer.CompanyName).ToList();
            });

        }

        public static async Task MakeJson()
        {
            List<CustomerEntity> cust = await AllCustomersForDataGridViewAsync();
            File.WriteAllText("Customers.json", JsonHelpers.Serialize<CustomerEntity>(cust));

            var contactTypes = Context.ContactType.ToList();
            File.WriteAllText("ContactType.json", JsonHelpers.Serialize<ContactType>(contactTypes));

            var contacts = Context.Contacts.ToList();
            File.WriteAllText("Contacts.json", JsonHelpers.Serialize<Contacts>(contacts));

            var countriesList = Context.Countries.ToList();
            File.WriteAllText("Countries.json", JsonHelpers.Serialize<Countries>(countriesList));

        }

        public static CustomerEntity CustomerByIdentifier(int identifier)
        {
            using (var context = new NorthwindContext())
            {
                return context.Customers.Select(Customers.Projection).FirstOrDefault(custEntity => custEntity.CustomerIdentifier == identifier);
            }
        }

        public static List<Countries> CountryList()
        {
            using (var context = new NorthwindContext())
            {
                return context.Countries.AsNoTracking().ToList();
            }
        }

        public static List<ContactType> ContactTypeList()
        {
            using (var context = new NorthwindContext())
            {
                return context.ContactType.AsNoTracking().ToList();
            }
        }

        public void UpdateMultipleRows(List<Customers> customers)
        {
            using (var context = new NorthwindContext())
            {
                context.Customers.UpdateRange(customers);
            }
        }

        public static Customers CustomerFirstOrDefault(int customerIdentifier) => Context.Customers.FirstOrDefault(customer => customer.CustomerIdentifier == customerIdentifier);
    }
}
