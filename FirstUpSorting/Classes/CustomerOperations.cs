﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityCoreExtensions;
using FirstUpSorting.LanguageExtensions;
using NorthClassLibrary.Classes;
using NorthClassLibrary.Contexts;
using NorthClassLibrary.Models;

namespace FirstUpSorting.Classes
{
    public class CustomerOperations
    {
        /// <summary>
        /// Perform a specialty sort where specific items will be first prior to
        /// the intended sort.
        /// </summary>
        /// <returns></returns>
        public static async Task<List<CustomerItem>> DemonstrationCustomOrdering()
        {

            using (var context = new NorthwindContext())
            {

                return await Task.Run(() =>
                {
                    List<CustomerItem> customerItemsList = context.Customers.Select(Customer.Projection).ToList();
                    return customerItemsList.OrderBy((customer) => customer.CompanyName, new SpecificOrdering()).ToList();
                });

            }

        }
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
                return await Task.Run(() => context.Customers.Select(Customer.Projection).ToList().Sort(propertyName, sortDirection));
            }

        }
        /// <summary>
        /// Get all column names for a model
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        /// <remarks>
        /// Example
        /// ModelColumnNameList("Customers")
        /// </remarks>
        public static List<string> ModelColumnNameList(string modelName)
        {
            using (var context = new NorthwindContext())
            {
                return context.ColumnNames(modelName);
            }
        }

    }
}