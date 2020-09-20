using System.Threading.Tasks;

namespace NorthEntityLibrary.Interfaces
{
    /// <summary>
    /// For demoing FindAsync in a generic repository
    /// </summary>
    /// <typeparam name="TEntity">Model to work with</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetTask(int id, string[] paths = null);
        Task<TEntity> GetWithIncludesTask(int id);
    }
}