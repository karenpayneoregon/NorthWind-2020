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
    public class OrdersTestOperation
    {
        public static List<OrderDetailItem> GetOrderDetailItems(int orderIdentifier)
        {
            using (var context = new NorthwindContext())
            {
                return context.OrderDetails.AsNoTracking()
                    .Where(od => od.OrderID == orderIdentifier)
                    .Select(od => new OrderDetailItem()
                    {
                        OrderID = orderIdentifier,
                        ProductName = od.Product.ProductName,
                        UnitPrice = od.UnitPrice,
                        Discount = od.Discount,
                        ProductID = od.ProductID,
                        Quantity = od.Quantity
                    }).ToList();
            }

        }

        public static async Task<List<Orders>> GetOrdersWithoutOrderDetails() 
        {
            using (var context = new NorthwindContext())
            {
                var results = await context
                    .Orders
                    .Include(ord => ord.OrderDetails)
                    .Where(q => !q.OrderDetails.Where(r => r.OrderID == q.OrderID).Any()).ToListAsync();

                return results;
            }
        }

        public static List<OrderItem> GetCustomerOrders(int customerIdentifier)
        {
            
            using (var context = new NorthwindContext())
            {
                return context
                    .Orders
                    .Include(order => order.ShipViaNavigation)
                    .Include(order => order.Employee)
                    .Where(order => order.CustomerIdentifier == customerIdentifier)
                    .Select(order => new OrderItem()
                    {
                        OrderID = order.OrderID,
                        CustomerIdentifier = customerIdentifier,
                        EmployeeID = order.EmployeeID,
                        EmployeeName = order.Employee.FirstName + " " + order.Employee.LastName,
                        Freight = order.Freight,
                        OrderDate = order.OrderDate,
                        RequiredDate = order.RequiredDate,
                        ShipAddress = order.ShipAddress,
                        ShipCity = order.ShipCity,
                        ShipCountry = order.ShipCountry,
                        ShipPostalCode = order.ShipPostalCode,
                        ShipRegion = order.ShipRegion,
                        ShipVia = order.ShipVia,
                        ShippedDate = order.ShippedDate,
                        ShipperName = order.ShipViaNavigation.CompanyName
                    })
                    .ToList();
            }

        }
    }
}
