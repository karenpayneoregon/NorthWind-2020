using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using North.Classes;
using North.Contexts;
using North.Interfaces;
using North.Models;

/*
 * Experimental extensions
 */
namespace North.LanguageExtensions
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Delegate | AttributeTargets.Field)]
    internal sealed class NotNullAttribute : Attribute { }

    public static class ExperimentExtensions
    {
        public static IEnumerable<ModelComment> Comments<T>(this T sender) where T : IModelBaseEntity
        {
            using (var context = new NorthwindContext())
            {
                IEntityType entityType = context.Model.FindRuntimeEntityType(typeof(T));

                if (entityType != null)
                {
                    return entityType.GetProperties().Select(property => new ModelComment
                    {
                        Name = property.Name,
                        Comment = string.IsNullOrWhiteSpace(property.GetComment()) ? property.Name : property.GetComment()
                    });
                }
                else
                {
                    return Enumerable.Empty<ModelComment>();
                }

            }
        }
        public static void Remove1<TEntity>([NotNull] InternalEntityEntry entity) where TEntity : class
        {
            
            



        }
        /// <summary>
        /// Get comments for properties of a model
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <param name="sender"></param>
        /// <param name="context">Active dbContext</param>
        /// <returns></returns>
        public static IEnumerable<ModelComment> Comments<T>(this T sender, DbContext context) where T : IModelBaseEntity
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            IEntityType entityType = context.Model.FindRuntimeEntityType(typeof(T));

            return entityType.GetProperties().Select(property => new ModelComment
            {
                Name = property.Name,
                Comment = property.GetComment()
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <remarks>
        /// For now
        /// var example = new Customers();
        /// var test2 = context.GetEntityProperties(example);
        /// </remarks>
        public static List<SqlColumn> GetEntityProperties<T>(this DbContext context, T model) where T : IModelBaseEntity 
        {

            if (context == null) throw new ArgumentNullException(nameof(context));

            var sqlColumnsList = new List<SqlColumn>();

            // ReSharper disable once AssignNullToNotNullAttribute
            IEnumerable<IProperty> properties = context.Model.FindEntityType(typeof(T)).GetProperties();
            //var keys = context.Model.FindEntityType(typeof(T)).GetKeys();

            foreach (IProperty itemProperty in properties)
            {
                var sqlColumn = new SqlColumn() { Name = itemProperty.Name };
                var comment = context.Model.FindEntityType(typeof(T)).FindProperty(itemProperty.Name).GetComment();

                sqlColumn.Description = string.IsNullOrWhiteSpace(comment) ? itemProperty.Name : comment;

                sqlColumn.IsPrimaryKey = itemProperty.IsKey();
                sqlColumn.IsForeignKey = itemProperty.IsForeignKey();
                sqlColumn.IsNullable = itemProperty.IsColumnNullable();

                sqlColumnsList.Add(sqlColumn);

            }

            return sqlColumnsList;
        }
        /// <summary>
        /// Get details for a model
        /// </summary>
        /// <param name="context">Active dbContext</param>
        /// <param name="modelName">Model name in context</param>
        /// <returns></returns>
        public static List<SqlColumn> GetEntityProperties(this DbContext context, string modelName) 
        {

            if (context == null) throw new ArgumentNullException(nameof(context));

            var entityType = context.Model.GetEntityTypes()
                .Select(eType => eType.ClrType)
                .FirstOrDefault(x => x.Name == modelName);

            var sqlColumnsList = new List<SqlColumn>();

            // ReSharper disable once AssignNullToNotNullAttribute
            IEnumerable<IProperty> properties = context.Model.FindEntityType(entityType).GetProperties();
            //var keys = context.Model.FindEntityType(entityType).GetKeys();

            foreach (IProperty itemProperty in properties)
            {
                var sqlColumn = new SqlColumn() { Name = itemProperty.Name };
                var comment = context.Model.FindEntityType(entityType).FindProperty(itemProperty.Name).GetComment();

                sqlColumn.Description = string.IsNullOrWhiteSpace(comment) ? itemProperty.Name : comment;

                sqlColumn.IsPrimaryKey = itemProperty.IsKey();
                sqlColumn.IsForeignKey = itemProperty.IsForeignKey();
                sqlColumn.IsNullable = itemProperty.IsColumnNullable();

                sqlColumnsList.Add(sqlColumn);

            }

            return sqlColumnsList;
        }
    }

}