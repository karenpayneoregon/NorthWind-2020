using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthEntityLibrary.Contexts;

namespace NorthEntityLibrary.Classes.Utility
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
