using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthClassLibrary.Contexts;
using NorthClassLibrary.Models;

namespace NorthClassLibrary.Classes.Utility
{
    public class HelperOperations
    {
        /// <summary>
        /// List of model names
        /// </summary>
        /// <returns>Model name as a list</returns>
        public static async Task<List<string>> ModelNameList()
        {
            using (var context =  new NorthwindContext())
            {
                return await Task.Run(() => context.Model
                    .GetEntityTypes()
                    .Select(entityType => entityType.ClrType)
                    .Select(type => type.Name)
                    .ToList());
            }
        }
    }
}
