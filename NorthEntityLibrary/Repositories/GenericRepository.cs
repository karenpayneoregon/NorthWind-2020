using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NorthClassLibrary.Models;
using NorthEntityLibrary.Contexts;
using NorthEntityLibrary.Interfaces;

namespace NorthEntityLibrary.Repositories
{
    /// <summary>
    /// Popular generic method to include navigation properties
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

        /// <summary>
        /// Get entity by primary key
        /// </summary>
        /// <param name="id">primary key to find</param>
        /// <param name="references">empty, one or more navigation property by name</param>
        /// <returns>Entity if found along with navigation items if specified</returns>
        public async Task<TEntity> GetTask(int id, string[] references = null)
        {
            var model = await _dbSet.FindAsync(id);

            if (references == null) return model;

            foreach (var reference in references)
            {
                _context.Entry((object) model).Reference(reference).Load();
            }

            return model;
        }
        /// <summary>
        /// Get entity by primary key
        /// </summary>
        /// <param name="id">primary key to find</param>
        /// <param name="references">empty, one or more navigation property by name</param>
        /// <returns>Entity if found along with navigation items if specified</returns>
        public TEntity Get(int id, string[] references = null)
        {
            var model = _dbSet.Find(id);
            
            if (references == null) return model;

            foreach (var reference in references)
            {
                _context.Entry((object)model).Reference(reference).Load();
            }

            return model;
        }
        /// <summary>
        /// Get entity by primary key
        /// </summary>
        /// <param name="id">primary key to find</param>
        /// <returns>Entity if found all navigation(s) are included</returns>
        public async Task<TEntity> GetWithIncludesTask(int id)
        {
            var model = await _dbSet.FindAsync(id);

            foreach (NavigationEntry navigation in _context.Entry(model).Navigations)
            {
                await navigation.LoadAsync();
            }

            return model;

        }
        /// <summary>
        /// Get entity by primary key
        /// </summary>
        /// <param name="id">primary key to find</param>
        /// <returns>Entity if found all navigation(s) are included</returns>
        public TEntity GetWithIncludes(int id)
        {
            var model = _dbSet.Find(id);

            foreach (NavigationEntry navigation in _context.Entry(model).Navigations)
            {
                navigation.Load();
            }

            return model;

        }
    }
}
