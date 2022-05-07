using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCoreExtensions.Classes;
using EntityCoreExtensions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCoreExtensions
{
    public static class DbContexts
    {

        /// <summary>
        /// List of model names
        /// </summary>
        /// <returns>Model name as a list</returns>
        /// <remarks>
        /// var names = await HelperOperations.ModelNameList();
        /// </remarks>
        public static async Task<List<string>> ModelNameList(DbContext context) =>
            await Task.Run(() => context.Model
                .GetEntityTypes()
                .Select(entityType => entityType.ClrType)
                .Select(type => type.Name)
                .ToList());

        /// <summary>
        /// Get details for a model
        /// </summary>
        /// <param name="context">Active dbContext</param>
        /// <param name="modelName">Model name in context</param>
        /// <returns>List&lt;SqlColumn&gt;</returns>
        public static List<SqlColumn> GetEntityProperties(this DbContext context, string modelName) 
        {

            if (context == null) throw new ArgumentNullException(nameof(context));

            var entityType = GetEntityType(context, modelName);

            var sqlColumnsList = new List<SqlColumn>();

            IEnumerable<IProperty> properties = context.Model.FindEntityType(entityType ?? 
                throw new InvalidOperationException()).GetProperties();

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
        /// Get type from model name
        /// </summary>
        /// <param name="context">Live DbContext</param>
        /// <param name="modelName">Valid model name</param>
        /// <returns></returns>
        private static Type GetEntityType(DbContext context, string modelName)
        {
            var entityType = context.Model.GetEntityTypes()
                .Select(eType => eType.ClrType)
                .FirstOrDefault(type => type.Name == modelName);
            return entityType;
        }

        /// <summary>
        /// Get model comments by model type
        /// </summary>
        /// <param name="context">Live DbContext</param>
        /// <param name="modelType">Model type</param>
        /// <returns>IEnumerable&lt;ModelComment&gt;</returns>
        /// <remarks>
        /// context.Comments(typeof(Customers));
        /// </remarks>
        public static IEnumerable<ModelComment> Comments(this DbContext context, Type modelType)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            IEntityType entityType = context.Model.FindRuntimeEntityType(modelType);

            return entityType.GetProperties().Select(property => new ModelComment
            {
                Name = property.Name,
                Comment = property.GetComment()
            });

        }
        /// <summary>
        /// Returns a list of column names for model
        /// </summary>
        /// <param name="context">Live DbContext</param>
        /// <param name="modelName">Existing model name</param>
        /// <returns></returns>
        public static List<string> ColumnNames(this DbContext context, string modelName)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var entityType = GetEntityType(context, modelName);

            var sqlColumnsList = new List<string>();

            IEnumerable<IProperty> properties = context.Model.FindEntityType(entityType ?? throw new InvalidOperationException()).GetProperties();

            foreach (IProperty itemProperty in properties)
            {
                sqlColumnsList.Add(itemProperty.Name);
            }

            return sqlColumnsList;


        }
        /// <summary>
        /// Get comments for a specific model
        /// </summary>
        /// <param name="context">Live DbContext</param>
        /// <param name="modelName">Model name to get comments for</param>
        /// <returns>IEnumerable&lt;ModelComment&gt;</returns>
        /// <remarks>
        /// context.Comments("Customers");
        /// </remarks>
        public static IEnumerable<ModelComment> Comments(this DbContext context, string modelName)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var entityType = GetEntityType(context, modelName);

            var commentList = new List<ModelComment>();

            IEnumerable<IProperty> properties = context.Model.FindEntityType(entityType ?? 
                throw new InvalidOperationException()).GetProperties();

            foreach (IProperty itemProperty in properties)
            {
                var sqlColumn = new ModelComment
                {
                    Name = itemProperty.Name,
                    Comment = context.Model.FindEntityType(entityType).FindProperty(itemProperty.Name).GetComment() ?? itemProperty.Name
                };


                commentList.Add(sqlColumn);

            }

            return commentList;

        }

        /// <summary>
        /// Generic reset for entities modified, added and deleted
        /// </summary>
        /// <param name="context"></param>
        public static void Reset(this DbContext context)
        {
            var entries = context.ChangeTracker.Entries()
                .Where(ee => ee.State != EntityState.Unchanged).ToArray();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }

}