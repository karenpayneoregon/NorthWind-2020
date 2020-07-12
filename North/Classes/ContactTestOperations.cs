using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using North.Contexts;

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
    }
}
