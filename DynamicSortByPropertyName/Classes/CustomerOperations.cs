using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicSortByPropertyName.LanguageExtensions;
using EntityCoreExtensions;
using NorthClassLibrary.Contexts;

namespace DynamicSortByPropertyName.Classes
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
        /// <summary>
        /// Get all column names for a specific model
        /// </summary>
        /// <param name="modelName">Existing model name</param>
        /// <returns>list of property/column names for model</returns>
        public static List<string> ModelColumnNameList(string modelName)
        {
            using (var context = new NorthwindContext())
            {
                return context.ColumnNames(modelName);
            }
        }

    }
}
