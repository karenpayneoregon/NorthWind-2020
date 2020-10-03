using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthClassLibrary.Models;

namespace NorthEntityLibrary.Classes
{
    /// <summary>
    /// Customers duplicate finder
    /// </summary>
    public class CustomersDuplicateFinder
    {

        /// <summary>
        /// Get duplicate customers by company name, contact name, contact title
        /// </summary>
        /// <returns></returns>
        public static async Task<List<CustomerEntity>> GetDuplicates()
        {
#if DEBUG
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("SQL");

            Console.ForegroundColor = originalColor;
#endif


            List<CustomerEntity> customerList = await CustomerOperations.AllCustomersAsync();

            var duplicates = from customerEntity in customerList
                select
                    new
                    {
                        Identifier = customerEntity.CustomerIdentifier,
                        CompanyName = customerEntity.CompanyName,
                        ContactId = customerEntity.ContactIdentifier,
                        ContactName = customerEntity.ContactName,
                        ContactTitle = customerEntity.ContactTitle,
                        Address = customerEntity.Street,
                        City = customerEntity.City,
                        PostalCode = customerEntity.PostalCode,
                        CountryId = customerEntity.CountryIdentifier
                    }
                into customerItems
                group customerItems by
                    new
                    {
                        CompanyName = customerItems.CompanyName,
                        ContactName = customerItems.ContactName,
                        ContactTitle = customerItems.ContactTitle
                    }
                into grouped
                where grouped.Count() > 1
                select grouped.Select(g =>
                    new DuplicateItem
                    (
                        g.Identifier,
                        g.CompanyName,
                        g.ContactId,
                        g.ContactName,
                        g.ContactTitle,
                        g.Address,
                        g.City,
                        g.PostalCode, 
                        g.CountryId
                    )
                );


            return (from item in duplicates
                from duplicate in item
                select new CustomerEntity()
                {
                    CustomerIdentifier = duplicate.Identifier,
                    CompanyName = duplicate.CompanyName,
                    ContactIdentifier = duplicate.ContactId,
                    ContactFullName = duplicate.ContactName,
                    ContactTitle = duplicate.ContactTitle,
                    Street = duplicate.Address,
                    City = duplicate.City,
                    PostalCode = duplicate.PostalCode,
                    CountryIdentifier = duplicate.CountryIdentifier
                }).ToList();
        }

        public static async Task<int> GetCustomerEntities()
        {
            return await CustomerOperations.WarmupTask();
        }
    }
}

        
