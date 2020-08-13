using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using North.Contexts;
using North.Models;

namespace North.Classes
{
    /// <summary>
    /// Operations dealing with contacts
    /// </summary>
    public class ContactTestOperations
    {

        /// <summary>
        /// Get all contacts with relations
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ContactItem>> GetContactsAsync()
        {
            return await Task.Run(async () =>
            {

                using (var context = new NorthwindContext())
                {
                    return await context.Contacts
                        .AsNoTracking()
                        .Include(contact => contact.ContactTypeIdentifierNavigation)
                        .Include(c => c.ContactDevices)
                        .ThenInclude(contactDevices => contactDevices.PhoneTypeIdentifierNavigation)
                        .Select(contact => new ContactItem
                        {
                            Id = contact.ContactId,
                            ContactName = contact.FirstName + " " + contact.LastName,
                            ContactType = contact.ContactTypeIdentifierNavigation.ContactTitle,
                            OfficePhone = contact.ContactDevices.FirstOrDefault(contactDevices => contactDevices.PhoneTypeIdentifier == 3).PhoneNumber ?? "(none)",
                            CellPhone = contact.ContactDevices.FirstOrDefault(contactDevices => contactDevices.PhoneTypeIdentifier == 2).PhoneNumber ?? "(none)",
                            HomePhone = contact.ContactDevices.FirstOrDefault(contactDevices => contactDevices.PhoneTypeIdentifier == 1).PhoneNumber ?? "(none)"
                        }).ToListAsync();
                }
            });
        }
        /// <summary>
        /// Get a single contact
        /// </summary>
        /// <param name="contactIdentifier"></param>
        /// <returns>Contact from contact id</returns>
        public static async Task<ContactItem> GetSingleContactByIdentifierAsync(int? contactIdentifier)
        {

            return await Task.Run(async () =>
            {

                using (var context = new NorthwindContext())
                {
                    return await context.Contacts
                        .AsNoTracking()
                        .Include(contact => contact.ContactTypeIdentifierNavigation)
                        .Include(c => c.ContactDevices)
                        .ThenInclude(contactDevices => contactDevices.PhoneTypeIdentifierNavigation)
                        .Select(contact => new ContactItem
                        {
                            Id = contact.ContactId,
                            ContactName = contact.FirstName + " " + contact.LastName,
                            ContactType = contact.ContactTypeIdentifierNavigation.ContactTitle,
                            OfficePhone = contact.ContactDevices.FirstOrDefault(contactDevices => contactDevices.PhoneTypeIdentifier == 3).PhoneNumber ?? "(none)",
                            CellPhone = contact.ContactDevices.FirstOrDefault(contactDevices => contactDevices.PhoneTypeIdentifier == 2).PhoneNumber ?? "(none)",
                            HomePhone = contact.ContactDevices.FirstOrDefault(contactDevices => contactDevices.PhoneTypeIdentifier == 1).PhoneNumber ?? "(none)"
                        }).FirstOrDefaultAsync(contactItem => contactItem.Id == contactIdentifier);
                }
            });
        }

        /// <summary>
        /// Cheap way to avoid attaching to another DbContext for changes in the ContactEditTestForm.
        /// </summary>
        public static NorthwindContext Context = new NorthwindContext();
        /// <summary>
        /// Get contact for editing
        /// </summary>
        /// <param name="contactIdentifier"></param>
        /// <returns></returns>
        public static async Task<Contacts> GetContactEditAsync(int contactIdentifier)
        {
            return await Task.Run(async () =>
            {
                return await Context.Contacts
                    .Include(contact => contact.ContactTypeIdentifierNavigation)
                    .Include(c => c.ContactDevices)
                    .ThenInclude(contactDevices => contactDevices.PhoneTypeIdentifierNavigation)
                    .FirstOrDefaultAsync(contact => contact.ContactId == contactIdentifier);
            });
        }
        /// <summary>
        /// Sole purpose is to populate a control e.g. ListBox or ComboBox etc.
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Contacts>> GetContactsForControlAsync() 
        {
            return await Task.Run(async () =>
            {
                using (var context = new NorthwindContext())
                {
                    return await context.Contacts.AsNoTracking().OrderBy(contact => contact.LastName).ToListAsync();
                }
            });
        }
        /// <summary>
        /// Get contact by contact identifier for view form
        /// </summary>
        /// <param name="contactIdentifier">A valid contact identifier</param>
        /// <returns></returns>
        public static async Task<Contacts> GetContactForViewAsync(int? contactIdentifier)
        {
            return await Task.Run(async () =>
            {
                using (var context = new NorthwindContext())
                {
                    return await context.Contacts
                        .AsNoTracking()
                        .Include(contact => contact.ContactTypeIdentifierNavigation)
                        .Include(c => c.ContactDevices)
                        .ThenInclude(contactDevices => contactDevices.PhoneTypeIdentifierNavigation)
                        .FirstOrDefaultAsync(c => c.ContactId == contactIdentifier);
                }
            });
        }
        /// <summary>
        /// Get all contact types
        /// </summary>
        /// <returns>List of all contact types</returns>
        public static List<ContactType> GetContactTypes()
        {
            using (var context = new NorthwindContext())
            {
                return context.ContactType.AsNoTracking().ToList();
            }
        }
        /// <summary>
        /// Raw example to obtain "Description" information for a column in
        /// a SQL-Server table.
        ///
        /// Note if the value for description in a column definition changes
        /// after reverse engineering it will not be reflected in the code
        /// found in configuration under the context folder.
        /// </summary>
        public static List<SqlColumn> PropertyGetColumnDescriptions(string modelName)
        {
            Type type = Context.Model.GetEntityTypes()
                .Select(entityType => entityType.ClrType)
                .FirstOrDefault(x => x.Name == modelName);

            var sqlColumnsList = new List<SqlColumn>();

            // ReSharper disable once AssignNullToNotNullAttribute
            IEnumerable<IProperty> properties = Context.Model.FindEntityType(type).GetProperties();
            var keys = Context.Model.FindEntityType(type).GetKeys();

            foreach (IProperty itemProperty in properties)
            {
                var sqlColumn = new SqlColumn() {Name = itemProperty.Name };
                var comment = Context.Model.FindEntityType(type).FindProperty(itemProperty.Name).GetComment();

                sqlColumn.Description = string.IsNullOrWhiteSpace(comment) ? itemProperty.Name : comment;

                if (keys.Count() >0)
                {
                    if (keys.FirstOrDefault().Properties[0].Name == itemProperty.Name)
                    {
                        sqlColumn.IsPrimaryKey = true;
                    }
                }

                sqlColumnsList.Add(sqlColumn);

            }

            return sqlColumnsList;

        }
        /// <summary>
        /// List of model names
        /// </summary>
        /// <returns></returns>
        public static async Task<List<string>> ModelNameList()
        {
            return await Task.Run(() =>Context.Model.GetEntityTypes().Select(entityType => entityType.ClrType).Select(type => type.Name).ToList());
        }
        /// <summary>
        /// Get selected model primary key
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public static string GetPrimaryKeyDemo(string modelName)
        {
            var identifier = "";

            Type type = Context.Model.GetEntityTypes()
                .Select(entityType => entityType.ClrType)
                .FirstOrDefault(x => x.Name == modelName);


            foreach (var key in Context.Model.FindEntityType(type).GetKeys())
            {
                foreach (var property in key.Properties)
                {
                    identifier = property.Name;

                    // get more defined
                    //if (property.ValueGenerated == ValueGenerated.OnAdd)
                    //{
                    //    identifier = property.Name;
                    //}
                }
            }

            return string.IsNullOrWhiteSpace(identifier) ? "none" : identifier;

        }
    }
}
