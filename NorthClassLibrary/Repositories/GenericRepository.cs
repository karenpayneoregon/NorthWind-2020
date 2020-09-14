using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthClassLibrary.Contexts;
using NorthClassLibrary.Interfaces;

namespace NorthClassLibrary.Repositories
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

        public async Task<TEntity> Get(int id, string[] paths = null)
        {
            var model = await _dbSet.FindAsync(id);

            if (paths == null) return model;

            foreach (var path in paths)
            {
                _context.Entry((object) model).Reference(path).Load();
            }

            return model;
        }
    }
}
