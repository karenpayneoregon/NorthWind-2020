using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWindCore.Contexts;

namespace NorthWindCore.Classes
{
    public class SuppliersTestOperations
    {
        public static async Task<List<Models.Suppliers>> GetSuppliersAsync()
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
