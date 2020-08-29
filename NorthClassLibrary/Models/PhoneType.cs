using System.Collections.Generic;
using North.Interfaces;

namespace NorthClassLibrary.Models
{
    public partial class PhoneType: IModelBaseEntity
    {
        public PhoneType()
        {
            ContactDevices = new HashSet<ContactDevices>();
        }

        public int Id => PhoneTypeIdenitfier;
        public int PhoneTypeIdenitfier { get; set; }
        public string PhoneTypeDescription { get; set; }

        public virtual ICollection<ContactDevices> ContactDevices { get; set; }
    }
}