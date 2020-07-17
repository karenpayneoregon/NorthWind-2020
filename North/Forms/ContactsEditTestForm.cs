using System;
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

            Shown += ContactsEditTestForm_Shown;
            Closing += ContactsEditTestForm_Closing;
        }
        
        private async void ContactsEditTestForm_Shown(object sender, EventArgs e)
        {
            ContactsComboBox.DataSource = await ContactTestOperations.GetContactsForControlAsync();
            ContactTypeComboBox.DataSource = ContactTestOperations.GetContactTypes();

            ContactsComboBox.SelectedIndexChanged += ContactsComboBox_SelectedIndexChanged;
            ContactTypeComboBox.SelectedIndexChanged += ContactTypeComboBox_SelectedIndexChanged;

            ContactChanged();

            ActiveControl = ContactsComboBox;

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
            if (ContactTestOperations.Context.ChangeTracker.HasChanges())
            {
                var changedContactNames = ContactTestOperations.Context.GetChangedContactsToContactEditForm();
                if (Question("There are changes, do you want to leave?"))
                {
                    Close();
                }
            }
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
