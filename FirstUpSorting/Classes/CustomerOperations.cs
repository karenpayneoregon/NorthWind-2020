using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthClassLibrary.Classes;
using NorthClassLibrary.Contexts;
using NorthClassLibrary.Models;

namespace FirstUpSorting.Classes
{
    public class CustomerOperations
    {
        public static async Task<List<CustomerItem>> DemonstrationCustomOrdering()
        {

            using (var context = new NorthwindContext())
            {

                return await Task.Run(() =>
                {
                    List<CustomerItem> customerItemsList = context.Customers.Select(Customer.Projection).ToList();
                    return customerItemsList.OrderBy((customer) => customer.CompanyName, new SpecificOrdering()).ToList();
                });

            }

        }

    }
}
