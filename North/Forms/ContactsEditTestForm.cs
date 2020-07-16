﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using North.Classes;
using North.LanguageExtensions;
using North.Models;

namespace North.Forms
{
    public partial class ContactsEditTestForm : Form
    {
        private readonly BindingSource _contactBindingSource = new BindingSource();
        private Contacts _contact;

        public ContactsEditTestForm()
        {
            InitializeComponent();

            Shown += ContactsEditTestForm_Shown;
        }
        
        private async void ContactsEditTestForm_Shown(object sender, EventArgs e)
        {
            ContactsComboBox.DataSource = await ContactTestOperations.GetContactsForControlAsync();
            ContactTypeComboBox.DataSource = ContactTestOperations.GetContactTypes();
            ContactsComboBox.SelectedIndexChanged += ContactsComboBox_SelectedIndexChanged;
            ContactTypeComboBox.SelectedIndexChanged += ContactTypeComboBox_SelectedIndexChanged;

            ActiveControl = ContactsComboBox;

        }

        private void RemoveControlBindings()
        {
            foreach (var textBox in this.TextBoxList().Where(textBox => textBox.DataBindings.Count > 0))
            {
                textBox.DataBindings.Clear();
            }
        }

        private async void ContactsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _contact = await ContactTestOperations.GetContactEditAsync(((Contacts)ContactsComboBox.SelectedItem).ContactId);

            _contactBindingSource.DataSource = _contact;

            RemoveControlBindings();

            FirstNameTextBox.DataBindings.Add("Text", _contactBindingSource, "FirstName");
            LastNameTextBox.DataBindings.Add("Text", _contactBindingSource, "LastName");

            ContactTypeComboBox.SelectedIndex = ContactTypeComboBox.FindString(_contact.ContactTypeIdentifierNavigation.ContactTitle);
           
        }

        private void ContactTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _contact.ContactTypeIdentifier = ((ContactType)ContactTypeComboBox.SelectedItem).ContactTypeIdentifier;
        }

        private void SaveCurrentContactButton_Click(object sender, EventArgs e)
        {
            ContactTestOperations.Context.SaveChanges();
        }
    }
}