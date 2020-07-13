using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using North.Contexts;

namespace North.Classes
{
    public class CategoryTestOperations
    {
        public static async Task<List<CategoryItem>> CategoryItems()
        {
            return await Task.Run(async () =>
                {

                    using (var context = new NorthwindContext())
                    {
                        return await context.Categories
                            .AsNoTracking()
                            .Select(cat => new CategoryItem()
                            {
                                CategoryID = cat.CategoryID,
                                CategoryName = cat.CategoryName
                            }).ToListAsync();
                    }
                }
            );
        }
    }
}


