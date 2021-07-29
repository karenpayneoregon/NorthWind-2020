using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NorthWindCore.Contexts;

namespace NorthWindCore.Classes
{
    public class ProductsTestOperations
    {
        /// <summary>
        /// Load products by category
        /// </summary>
        /// <param name="categoryIdentifier">category key</param>
        public static List<ProductItem> GetProductsByCategory(int categoryIdentifier)
        {
            using var context = new NorthwindContext();
            return context.Products
                .AsNoTracking()
                .Include(product => product.Supplier)
                .Where(product => product.CategoryID == categoryIdentifier)
                .Select(product => new ProductItem()
                {
                    ProductId = product.ProductID,
                    ProductName = product.ProductName,
                    SupplierId = product.SupplierID,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock,
                    UnitsOnOrder = product.UnitsOnOrder,
                    ReorderLevel = product.ReorderLevel,
                    Discontinued = product.Discontinued,
                    DiscontinuedDate = product.DiscontinuedDate,
                    SupplierContactName = product.Supplier.ContactName,
                    SupplierContactTitle = product.Supplier.ContactTitle,
                    SupplierName = product.Supplier.CompanyName,
                    SupplierPhone = product.Supplier.Phone
                })
                .OrderBy(product => product.ProductName)
                .ToList();
        }
    }
}
