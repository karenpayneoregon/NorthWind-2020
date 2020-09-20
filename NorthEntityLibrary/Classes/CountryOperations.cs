using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthClassLibrary.Models;
using NorthEntityLibrary.Classes;
using NorthEntityLibrary.Contexts;
using NorthEntityLibrary.Models;

namespace NorthEntityLibrary.Classes
{
    public class CountryOperations
    {
        /// <summary>
        /// Country names in country table
        /// </summary>
        /// <param name="includeRemoveFilterItem">if true inserts "Remove filter as first item"</param>
        /// <returns>Country names</returns>
        public static List<string> CountryNameList(bool includeRemoveFilterItem)
        {
            using (var context = new NorthwindContext())
            {
                var countryNames = context.Countries
                    .AsNoTracking()
                    .Select(country => country.Name)
                    .ToList();

                if (includeRemoveFilterItem)
                {
                    countryNames.Insert(0, "Remove filter");
                }
               

                return countryNames;
            }
        }
        /// <summary>
        /// Get all Countries for DataGridView ComboBox column
        /// </summary>
        /// <returns>List of countries</returns>
        public static async Task<List<Countries>> CountriesAsync() 
        {
            using (var context = new NorthwindContext())
            {
                return await Task.Run(() => context
                    .Countries
                    .AsNoTracking().ToListAsync());
            }
        }
        /// <summary>
        /// Gets all countries with customer count
        /// </summary>
        /// <returns></returns>
        public static async Task<List<CountryItem>> GetCountriesWithCustomerCountAsync()
        {

            using (var context = new NorthwindContext())
            {
                return await Task.Run(() => context
                    .Countries
                    .AsNoTracking()
                    .Include(country => country.Customers)
                    .Select(country => new CountryItem()
                    {
                        Id = country.CountryIdentifier,
                        Name = country.Name,
                        CustomerCount = country.Customers.Count
                    })
                    .ToListAsync());
            }
        }
    }
}
