using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthClassLibrary.Contexts;
using SortLibrary;
using UtilityTestProject.Classes;

namespace NorthClassLibrary
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
    }
}
