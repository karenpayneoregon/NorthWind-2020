using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace North.Models
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
        [JsonIgnore]
        public virtual ICollection<Contacts> Contacts { get; set; }
        [JsonIgnore]
        public virtual ICollection<Customers> Customers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}