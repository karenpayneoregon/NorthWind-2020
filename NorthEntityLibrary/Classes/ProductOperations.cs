using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NorthEntityLibrary.Contexts;

namespace NorthEntityLibrary.Classes
{
    public class ProductOperations
    {
        public static NorthwindContext Context { get; } = new NorthwindContext();
        /// <summary>
        /// Get products by category and discontinued 
        /// </summary>
        /// <param name="categoryIdentifier">category key</param>
        /// <param name="discontinued">true or false </param>
        /// <returns></returns>
        public static async Task<List<Product>> GetProductsByCategory(int categoryIdentifier, bool discontinued)
        {
            var productList = new List<Product>();

            await Task.Run(async () =>
            {

                productList = await Context.Products
                    .Include(product => product.Supplier)
                    .Where(product => 
                        product.CategoryID == categoryIdentifier && 
                        product.Discontinued == discontinued && 
                        product.UnitsInStock > 0)
                    .Select(Product.Projection)
                    .ToListAsync();

            });

            return productList;
        }
        public static async Task<List<Product>> GetProducts()
        {
            var productList = new List<Product>();

            await Task.Run(async () =>
            {

                productList = await Context.Products
                    .Include(product => product.Supplier)
                    .Include(product => product.Category)
                    .Select(Product.Projection)
                    .ToListAsync();

            });

            return productList;
        }

        public static string Serialize(List<Product> products)
        {
            return JsonConvert.SerializeObject(products);
        }

    }
}
