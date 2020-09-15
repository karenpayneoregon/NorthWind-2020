using System;
using System.Linq.Expressions;
using NorthClassLibrary.Models;

namespace NorthClassLibrary.Classes
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }

        public override string ToString() => ProductName;

        public static Expression<Func<Products, Product>> Projection =>
            product => new Product()
            {
                ProductId = product.ProductID,
                ProductName = product.ProductName,
                SupplierName = product.Supplier.CompanyName,
                SupplierId = product.SupplierID,
                QuantityPerUnit = product.QuantityPerUnit,
                ReorderLevel = product.ReorderLevel,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder
            };

    }
}