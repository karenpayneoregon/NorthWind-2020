using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NorthEntityLibrary.Contexts;
using NorthEntityLibrary.Interfaces;

namespace NorthEntityLibrary.Repositories
{
    /// <summary>
    /// Popular generic method to include navigation properties
    ///
    /// Taken from
    /// https://entityframework.net/knowledge-base/40360512/findasync-and-include-linq-statements
    ///
    /// With slight modifications where the dbContext is not passed in. If this was for a library
    /// for multiple solutions then it makes sense to have the dbContext passed in on the constructor.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly NorthwindContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository()
        {
            _context = new NorthwindContext();
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetTask(int id, string[] paths = null)
        {
            var model = await _dbSet.FindAsync(id);

            if (paths == null) return model;

            foreach (var path in paths)
            {
                _context.Entry((object) model).Reference(path).Load();
            }

            return model;
        }

        public async Task<TEntity> GetWithIncludesTask(int id)
        {
            var model = await _dbSet.FindAsync(id);

            foreach (NavigationEntry navigation in _context.Entry(model).Navigations)
            {
                await navigation.LoadAsync();
            }

            return model;

        }
    }
}
