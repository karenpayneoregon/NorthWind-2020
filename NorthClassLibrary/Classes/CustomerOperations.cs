using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthClassLibrary.Contexts;
using NorthClassLibrary.Models;
using SortLibrary;
using UtilityTestProject.Classes;

namespace NorthClassLibrary.Classes
{
    public class CustomerOperations
    {
        /// <summary>
        /// Sort by property name
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="sortDirection"><see cref="SortDirection"/></param>
        /// <returns></returns>
        /// <remarks>
        /// Example usage
        /// await CustomerOperations.CustomerSort("CountryName", SortDirection.Descending);
        /// </remarks>
        public static async Task<List<CustomerItem>> CustomerSort(string propertyName, SortDirection sortDirection = SortDirection.Ascending)
        {

            using (var context = new NorthwindContext())
            {
                return await Task.Run(() => context
                    .Customers
                    .Select(Customer.Projection)
                    .ToList()
                    .SortByPropertyName(propertyName, sortDirection));
            }

        }

        public static async Task<List<Customers>> SelectTopFiveCustomersAsync()
        {
            using (var context = new NorthwindContext())
            {
                return await Task.Run(() => context
                    .Customers.Take(5).ToList());

            }
        }
        /// <summary>
        /// Update five records read from SelectTopFiveCustomersAsync()
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool UpdateTopFiveCustomers(IEnumerable<object> items)
        {
            // set modified date for each entity, normally 
            // this would be done in a before save in the DbContext
            foreach (var item in items)
            {
                item.GetType().GetProperty(name: "ModifiedDate")
                    ?.SetValue(obj: item, value: DateTime.Now);
            }

            using (var context = new NorthwindContext())
            {
                try
                {
                    context.UpdateRange(entities: items);
                    return context.SaveChanges() == 5;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static async Task<bool> UpdateRange<T>(List<T> items) where T : class, new()
        {

            using (var context = new NorthwindContext())
            {
                context.UpdateRange(items);
                return await context.SaveChangesAsync() == 5;
            }

        }
        /// <summary>
        /// Simple example for AttachRange, SaveChanges will return 0
        /// </summary>
        /// <param name="items">Customers list</param>
        /// <returns>true for SaveChanges returns 0</returns>
        public static bool AttachCustomersRange(List<Customers> items) 
        {

            using (var context = new NorthwindContext())
            {
                context.AttachRange(items);

                var unChanged = items
                    .Select(customer => context.Entry(customer).State)
                    .All(entityState => entityState == EntityState.Unchanged);

                return context.SaveChanges() == 0 && unChanged;

            }

        }
    }
}
