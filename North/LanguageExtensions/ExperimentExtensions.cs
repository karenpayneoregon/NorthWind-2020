using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using North.Classes;
using North.Contexts;
using North.Interfaces;

namespace North.LanguageExtensions
{
    public static class ExperimentExtensions
    {
        public static IEnumerable<ModelComment> Comments<T>(this T sender) where T : IBaseModelEntity
        {
            using (var context = new NorthwindContext())
            {
                IEntityType entityType = context.Model.FindRuntimeEntityType(typeof(T));

                return entityType.GetProperties().Select(property => new ModelComment
                {
                    Name = property.Name,
                    Comment = RelationalPropertyExtensions.GetComment(property)
                });
            }
        }
        public static IEnumerable<ModelComment> Comments<T>(this T sender, NorthwindContext dbContext) where T : IBaseModelEntity
        {
            IEntityType entityType = dbContext.Model.FindRuntimeEntityType(typeof(T));
            dbContext.Database.CanConnectAsync();
            return entityType.GetProperties().Select(property => new ModelComment
            {
                Name = property.Name,
                Comment = RelationalPropertyExtensions.GetComment(property)
            });
        }
    }
}