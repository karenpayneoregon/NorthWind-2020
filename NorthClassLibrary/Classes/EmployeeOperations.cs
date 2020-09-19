using NorthClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthClassLibrary.Contexts;
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
        /// <summary>
        /// Get changes for any property changed as in
        /// this case changes are being tracked
        /// </summary>
        /// <returns>Changed properties for single Employee</returns>
        /// <remarks>Generic names are used in the returning object</remarks>
        public static List<Tuple<string, object, object>> GetChanges()
        {
            var changes = new List<Tuple<string, object, object>>();
            using (var context = new NorthwindContext())
            {
                var employee = context.Employees.FirstOrDefault();

                // ReSharper disable once PossibleNullReferenceException
                employee.City = "Salem";
                employee.CountryIdentifier = 9;


                var entry = context.Entry(employee);

                foreach (var item in entry.CurrentValues.Properties)
                {
                    var propEntry = entry.Property(item.Name);

                    if (propEntry.IsModified)
                    {
                        changes.Add(new Tuple<string, object, object>(
                            item.Name,
                            propEntry.OriginalValue,
                            propEntry.CurrentValue));

                    }
                }

                return changes;

            }

        }
        /// <summary>
        /// Get changes for any property changed as in
        /// this case changes are being tracked
        /// </summary>
        /// <returns>Changed properties for single Employee</returns>
        /// <remarks>English names are used in the returning object</remarks>
        public static List<(string PropertyName, object OriginalValue, object CurrentValue)> GetChanges1()
        {
            var results = new List<(string, object, object)>();

            using (var context = new NorthwindContext())
            {
                var employee = context.Employees.FirstOrDefault();

                // ReSharper disable once PossibleNullReferenceException
                employee.City = "Salem";
                employee.CountryIdentifier = 9;


                var entry = context.Entry(employee);

                foreach (var item in entry.CurrentValues.Properties)
                {
                    var propEntry = entry.Property(item.Name);

                    if (propEntry.IsModified)
                    {
                        results.Add((item.Name, propEntry.OriginalValue, propEntry.CurrentValue));
                    }
                }

                return results;

            }

        }
    }
}
