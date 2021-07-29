using System.Collections.Generic;
using System.Linq;
using NorthWindCore.Contexts;
using NorthWindCore.Models;

namespace NorthWindCore.Classes
{
    public class EmployeeTestOperations
    {
        public static List<Employees> AllEmployees()
        {
            using (var context = new NorthwindContext())
            {
                return context.Employees.ToList();
            }
        }
    }
}
