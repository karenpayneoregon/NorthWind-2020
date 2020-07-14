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
    public class SuppliersTestOperations
    {
        public static async Task<List<Suppliers>> GetSuppliersAsync()
        {

            return await Task.Run(async () =>
                {

                    using (var context = new NorthwindContext())
                    {
                        return await context.Suppliers
                            .AsNoTracking()
                            .Include(supplier => supplier.CountryIdentifierNavigation)
                            .OrderBy(supplier => supplier.CompanyName)
                            .ToListAsync();
                    }

                }
            );

        }
    }
}
