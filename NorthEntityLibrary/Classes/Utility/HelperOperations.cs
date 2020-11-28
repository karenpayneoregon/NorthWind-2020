using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using North.Interfaces;
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
        /// <summary>
        /// Generic method to get a single entity
        /// https://entityframework.net/knowledge-base/37697161/how-can-i-write-a-generic-query-with-ef-and-csharp
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public T GetEntity<T>(int entityId) where T : class, IModelBaseEntity
        {
            using (var context = new NorthwindContext())
            {
                return (context.Set<T>().FirstOrDefault(items => items.Id == entityId));
            }
        }
    }
}
