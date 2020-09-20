using System.Collections.Generic;
using NorthClassLibrary.Models;

namespace NorthEntityLibrary.Models
{
    public partial class ContactType 
    {
        public ContactType()
        {
            Contacts = new HashSet<Contacts>();
            Customers = new HashSet<Customers>();
            Employees = new HashSet<Employees>();
        }

        public int ContactTypeIdentifier { get; set; }
        public string ContactTitle { get; set; }

        public virtual ICollection<Contacts> Contacts { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}