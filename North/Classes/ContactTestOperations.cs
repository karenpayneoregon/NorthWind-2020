using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using North.Contexts;
using North.Models;

namespace North.Classes
{
    public class ContactTestOperations
    {

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
        public static NorthwindContext Context = new NorthwindContext();
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

        public static async Task<List<Contacts>> GetContactsForControlAsync() 
        {
            return await Task.Run(async () =>
            {

                using (var context = new NorthwindContext())
                {
                    return await context.Contacts.AsNoTracking().ToListAsync();


                }
            });
        }

        public static List<ContactType> GetContactTypes()
        {
            using (var context = new NorthwindContext())
            {
                return context.ContactType.ToList();
            }
        }
    }
}
