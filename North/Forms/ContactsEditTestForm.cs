using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using North.Classes;
using North.LanguageExtensions;
using North.Models;
using static North.Classes.Helpers.Dialogs;

namespace North.Forms
{
    public partial class ContactsEditTestForm : Form
    {
        private readonly BindingSource _contactBindingSource = new BindingSource();
        private Contacts _contact;

        public ContactsEditTestForm()
        {
            InitializeComponent();

            //Shown += ContactsEditTestForm_Shown;
            //Closing += ContactsEditTestForm_Closing;
        }
        
        private async void ContactsEditTestForm_Shown(object sender, EventArgs e)
        {
            ContactsComboBox.DataSource = await ContactTestOperations.GetContactsForControlAsync();
            ContactTypeComboBox.DataSource = ContactTestOperations.GetContactTypes();

            ContactsComboBox.SelectedIndexChanged += ContactsComboBox_SelectedIndexChanged;
            ContactTypeComboBox.SelectedIndexChanged += ContactTypeComboBox_SelectedIndexChanged;

            OfficePhoneTextBox.Validating += OfficePhoneTextBox_Validating;
            HomePhoneTextBox.Validating += HomePhoneTextBox_Validating;
            CellPhoneNumber.Validating += CellPhoneNumber_Validating;

            ContactChanged();

            ActiveControl = ContactsComboBox;

        }

        private void CellPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            var phone = _contact.ContactDevices.FirstOrDefault(x => x.PhoneTypeIdentifier == 2);
            if (phone != null)
            {
                // Update phone number
                phone.PhoneNumber = CellPhoneNumber.Text;
            }
            else
            {
                // no current cell number, add one
                if (string.IsNullOrWhiteSpace(CellPhoneNumber.Text)) return;
                var contactDevice = new ContactDevices() { ContactId = _contact.ContactId, PhoneTypeIdentifier = 2, PhoneNumber = CellPhoneNumber.Text };
                ContactTestOperations.Context.ContactDevices.Add(contactDevice);
            }
        }

        private void HomePhoneTextBox_Validating(object sender, CancelEventArgs e)
        {
            var phone = _contact.ContactDevices.FirstOrDefault(x => x.PhoneTypeIdentifier == 1);
            if (phone != null)
            {
                // Update phone number
                phone.PhoneNumber = HomePhoneTextBox.Text;
            }
            else
            {
                // no current home number, add one
                if (string.IsNullOrWhiteSpace(HomePhoneTextBox.Text)) return;
                var contactDevice = new ContactDevices() { ContactId = _contact.ContactId, PhoneTypeIdentifier = 1, PhoneNumber = HomePhoneTextBox.Text };
                ContactTestOperations.Context.ContactDevices.Add(contactDevice);
            }
        }
        /// <summary>
        /// Update phone number, as this code sample was delivered there is
        /// a office phone number for each contact. For in the wild use the
        /// logic in HomePhoneTextBox.Validating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OfficePhoneTextBox_Validating(object sender, CancelEventArgs e)
        {
            var phone = _contact.ContactDevices.FirstOrDefault(x => x.PhoneTypeIdentifier == 3);
            if (phone != null) phone.PhoneNumber = OfficePhoneTextBox.Text;
        }

        /// <summary>
        /// Can not bind twice so we need to remove bindings if there are bindings which
        /// there are passed the first time selecting a contact
        /// </summary>
        private void RemoveControlBindings()
        {
            foreach (var textBox in this.TextBoxList().Where(textBox => textBox.DataBindings.Count > 0))
            {
                textBox.DataBindings.Clear();
            }
        }
        /// <summary>
        /// Call method below, see comments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactsComboBox_SelectedIndexChanged(object sender, EventArgs e) => ContactChanged();

        /// <summary>
        /// Setup contact properties in various controls
        /// </summary>
        private async void ContactChanged()
        {
            _contact = await ContactTestOperations.GetContactEditAsync(
                ((Contacts)ContactsComboBox.SelectedItem).ContactId);
            
            _contactBindingSource.DataSource = _contact;

            RemoveControlBindings();

            FirstNameTextBox.DataBindings.Add("Text", _contactBindingSource, "FirstName");
            LastNameTextBox.DataBindings.Add("Text", _contactBindingSource, "LastName");
            ContactIdTextBox.DataBindings.Add("Text", _contactBindingSource, "ContactId");
            var test = _contact.ContactDevices.Where(x => x.ContactId == _contact.ContactId).ToList();

            var officePhone = test.FirstOrDefault(x => x.PhoneTypeIdentifier == 3);
            OfficePhoneTextBox.Text = officePhone?.PhoneNumber;

            var homePhone = test.FirstOrDefault(x => x.PhoneTypeIdentifier == 1);
            HomePhoneTextBox.Text = homePhone?.PhoneNumber;

            var cellPhone = test.FirstOrDefault(x => x.PhoneTypeIdentifier == 2);
            CellPhoneNumber.Text = cellPhone?.PhoneNumber;

            ContactTypeComboBox.SelectedIndex = 
                ContactTypeComboBox.FindString(_contact.ContactTypeIdentifierNavigation.ContactTitle);
            
        }
        /// <summary>
        /// Handle updating the contact type manually as there is no data binding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _contact.ContactTypeIdentifier = ((ContactType)ContactTypeComboBox.SelectedItem)
                .ContactTypeIdentifier;
        }
        /// <summary>
        /// Save changes for any updates. Optionally create a variable to capture
        /// the count on ContactTestOperations.Context.SaveChanges();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveCurrentContactButton_Click(object sender, EventArgs e)
        {
            try
            {
                ContactTestOperations.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Close/cancel, first see if there are any changes and
        /// if there are prompt to stay or lose changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ContactsEditTestForm_Closing(object sender, CancelEventArgs e)
        {
            if (ContactTestOperations.Context.ChangeTracker.HasChanges())
            {
                var changedContactNames = ContactTestOperations.Context.GetChangedContactsToContactEditForm();
                e.Cancel = !Question("There are changes, do you want to leave?");
            }
        }
    }
}
