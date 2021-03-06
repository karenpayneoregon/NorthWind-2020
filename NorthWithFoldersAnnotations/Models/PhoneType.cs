﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWithFoldersAnnotations.Models
{
    [Table("PhoneType")]
    public partial class PhoneType
    {
        public PhoneType()
        {
            ContactDevices = new HashSet<ContactDevice>();
        }

        [Key]
        public int PhoneTypeIdenitfier { get; set; }
        public string PhoneTypeDescription { get; set; }

        [InverseProperty(nameof(ContactDevice.PhoneTypeIdentifierNavigation))]
        public virtual ICollection<ContactDevice> ContactDevices { get; set; }
    }
}