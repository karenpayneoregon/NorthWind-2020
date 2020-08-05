using System.Collections.Generic;
using System.Linq;
using North.Contexts;
using North.Models;

namespace North.Classes
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
