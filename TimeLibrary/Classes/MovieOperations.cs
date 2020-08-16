using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeLibrary.Contexts;
using TimeLibrary.Models;

namespace TimeLibrary.Classes
{
    public class MovieOperations
    {
        /// <summary>
        /// Get all available movies
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Movies>> GetMovies()
        {
            return await Task.Run(async () =>
            {
                using (var context = new DateTimeContext())
                {
                    return await context.Movies.AsNoTracking().ToListAsync();
                }
            });
        }
        /// <summary>
        /// Add new movie
        /// </summary>
        /// <param name="movies"></param>
        /// <returns></returns>
        public static bool AddMovie(Movies movies)
        {
            using (var context = new DateTimeContext())
            {
                context.Attach(movies).State = EntityState.Added;
                return context.SaveChanges() == 1;
            }
        }
    }
}
