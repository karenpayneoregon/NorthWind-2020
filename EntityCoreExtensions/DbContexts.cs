using System;
using System.Collections.Generic;
using System.Linq;
using EntityCoreExtensions.Classes;
using EntityCoreExtensions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCoreExtensions
{
    public static class DbContexts
    {
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
                .FirstOrDefault(type => type.Name == modelName);

            var sqlColumnsList = new List<SqlColumn>();

            IEnumerable<IProperty> properties = context.Model.FindEntityType(entityType ?? throw new InvalidOperationException()).GetProperties();

            foreach (IProperty itemProperty in properties)
            {
                var sqlColumn = new SqlColumn() { Name = itemProperty.Name };
                var comment = context.Model.FindEntityType(entityType).FindProperty(itemProperty.Name).GetComment();

                sqlColumn.Description = string.IsNullOrWhiteSpace(comment) ? itemProperty.Name : comment;

                sqlColumn.IsPrimaryKey = itemProperty.IsKey();
                sqlColumn.IsForeignKey = itemProperty.IsForeignKey();
                sqlColumn.IsNullable = itemProperty .IsColumnNullable();

                sqlColumnsList.Add(sqlColumn);

            }

            return sqlColumnsList;
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
        /// Generic reset for entities modified, added and deleted
        /// </summary>
        /// <param name="context"></param>
        public static void Reset(this DbContext context)
        {
            var entries = context.ChangeTracker.Entries().Where(ee => ee.State != EntityState.Unchanged).ToArray();
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