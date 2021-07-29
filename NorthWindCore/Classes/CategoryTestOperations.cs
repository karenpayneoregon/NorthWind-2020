using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWindCore.Contexts;

namespace NorthWindCore.Classes
{
    public class CategoryTestOperations
    {
        public static async Task<List<CategoryItem>> CategoryItems()
        {
            return await Task.Run<List<CategoryItem>>(async () =>
                {
                    using var context = new NorthwindContext();
                    return await Queryable.Select(context.Categories
                            .AsNoTracking(), cat => new CategoryItem()
                        {
                            CategoryId = cat.CategoryID,
                            CategoryName = cat.CategoryName
                        })
                        .ToListAsync();
                }
            );
        }
    }
}


