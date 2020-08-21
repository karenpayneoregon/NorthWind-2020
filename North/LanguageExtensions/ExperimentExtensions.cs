using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using North.Classes;
using North.Contexts;

namespace North.LanguageExtensions
{
    public static class ExperimentExtensions
    {
        public static IEnumerable<ModelComment> Comments<T>(this T sender)
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
    }
}