using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindCore.Classes.Projections
{
    /// <summary>
    /// Unfinished projection
    /// </summary>
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static Expression<Func<Contact, Contact>> Projection =>
            (contact) => new Contact()
            {
                ContactId = contact.ContactId, 
                FirstName = contact.FirstName, 
                LastName = contact.LastName
            };
    }
}
