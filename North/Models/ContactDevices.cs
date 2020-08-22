﻿
using System;
using System.Collections.Generic;
using North.Interfaces;

namespace North.Models
{
    public partial class ContactDevices: IModelBaseEntity
    {
        public int Id => id;
        public int id { get; set; }
        public int? ContactId { get; set; }
        public int? PhoneTypeIdentifier { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual PhoneType PhoneTypeIdentifierNavigation { get; set; }
    }
}