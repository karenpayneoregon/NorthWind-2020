using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NorthWindCore.LanguageExtensions
{
    public static class DbContextExtensions
    {
        public static async Task<int> SaveChangesWithValidationAsync(this DbContext context)
        {
            IEnumerable<EntityEntry> recordsToValidate = context.ChangeTracker.Entries();
            foreach (var recordToValidate in recordsToValidate)
            {
                var entity = recordToValidate.Entity;
                var validationContext = new ValidationContext(entity);
                var results = new List<ValidationResult>();
                if (!Validator.TryValidateObject(entity, validationContext, results, true))
                {
                    var messages = results
                        .Select(validationResult => validationResult.ErrorMessage)
                        .ToList()
                        .Aggregate((message, nextMessage) => $"{message}, {nextMessage}");

                    throw new ApplicationException($"Unable to save changes for {entity.GetType().FullName} due to error(s): {messages}");
                }
            }

            return await context.SaveChangesAsync();

        }

        public static void Reset(this DbContext context)
        {
            var entries = context.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged).ToArray();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.State = EntityState.Unchanged;
                }
                else if (entry.State == EntityState.Added)
                {
                    entry.State = EntityState.Detached;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.Reload();
                }
            }
        }
    }
}