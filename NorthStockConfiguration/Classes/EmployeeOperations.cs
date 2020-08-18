using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NorthStockConfiguration.Classes
{
    public class EmployeeOperations
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Employees>> GetEmployeeListAsync()
        {
            return await Task.Run(async () =>
                {

                    using (var context = new NorthwindContext())
                    {
                        return await context.Employees.AsNoTracking()
                            .ToListAsync();
                    }

                }
            );
        }
        /// <summary>
        /// Update a single employee
        /// </summary>
        /// <param name="employee">Valid employee</param>
        /// <returns></returns>
        public static bool Update(Employees employee)
        {
            using (var context = new NorthwindContext())
            {

                context.Attach(employee).State = EntityState.Modified;
                return context.SaveChanges() == 1;

            }
        }
    }
}
