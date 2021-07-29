using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NorthWindCore.Contexts;

namespace NorthWindCore.Classes
{
    public class CountryTestOperations
    {
        public static List<CountryItem> GetCountries()
        {
            using var context = new NorthwindContext();
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
