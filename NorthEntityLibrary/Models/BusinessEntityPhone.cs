using System;

namespace NorthEntityLibrary.Models
{
    public partial class BusinessEntityPhone
    {
        public int BusinessEntityPhoneID { get; set; }
        public string PhoneNumber { get; set; }
        public int? PhoneNumberTypeID { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}