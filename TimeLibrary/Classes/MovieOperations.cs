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
    }
}
