using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<CustomerEntity> customerList = await CustomerOperations.AllCustomersAsync();
            List<CustomerEntity> customerListClone = new List<CustomerEntity>();

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


            foreach (IEnumerable<DuplicateItem> item in duplicates)
            {
                foreach (DuplicateItem duplicate in item)
                {
                    customerListClone.Add(new CustomerEntity()
                    {
                        CustomerIdentifier = duplicate.Identifier,
                        CompanyName = duplicate.CompanyName,
                        ContactIdentifier = duplicate.ContactId,
                        ContactFullName = duplicate.ContactName,
                        ContactTitle = duplicate.ContactTitle,
                        Street = duplicate.Address,
                        City = duplicate.City,
                        PostalCode = duplicate.PostalCode,
                        CountryIdentifier =  duplicate.CountryIdentifier
                    });
                }
            }

            return customerListClone;
        }
    }
}

        
