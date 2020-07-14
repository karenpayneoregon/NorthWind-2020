using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using North.Contexts;
using North.Models;

namespace North.Classes
{
    public class CountryTestOperations
    {
        public static List<CountryItem> GetCountries()
        {
            using (var context = new NorthwindContext())
            {
                var countries = context
                    .Countries
                    .AsNoTracking()
                    .Include(country => country.Customers)
                    .Select(country => new CountryItem()
                    {
                        Id = country.CountryIdentifier,
                        Name = country.Name, CustomerCount = country.Customers.Count
                    })
                    .ToList();

                return countries;
            }
        }
    }
}
