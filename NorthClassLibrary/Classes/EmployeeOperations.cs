using NorthClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthClassLibrary.Models;

namespace NorthClassLibrary.Classes
{
    public class EmployeeOperations
    {
        public static async Task<Employees> GenericRepositoryFindAsync(string[] paths)
        {
            var repo = new GenericRepository<Employees>();
            return await repo.Get(3, paths);
        }

    }
}
