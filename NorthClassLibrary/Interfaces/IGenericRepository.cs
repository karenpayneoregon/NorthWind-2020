using System.Threading.Tasks;

namespace NorthClassLibrary.Interfaces
{
    /// <summary>
    /// For demoing FindAsync in a generic repository
    /// </summary>
    /// <typeparam name="TEntity">Model to work with</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id, string[] paths = null);
    }
}