﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace North.Models
{
    public partial class Contacts : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private int? _contactTypeIdentifier;

        public Contacts()
        {
            ContactDevices = new HashSet<ContactDevices>();
            Customers = new HashSet<Customers>();
        }

        public int ContactId { get; set; }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public int? ContactTypeIdentifier
        {
            get => _contactTypeIdentifier;
            set
            {
                _contactTypeIdentifier = value;
                OnPropertyChanged();
            }
        }

        public virtual ContactType ContactTypeIdentifierNavigation { get; set; }
        public virtual ICollection<ContactDevices> ContactDevices { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}