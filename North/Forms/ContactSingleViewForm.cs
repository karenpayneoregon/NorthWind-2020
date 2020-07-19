using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using North.Models;

namespace North.Forms
{
    public partial class ContactSingleViewForm : Form
    {
        private Contacts _contact;
        public ContactSingleViewForm()
        {
            InitializeComponent();
        }
        public ContactSingleViewForm(Contacts contact)
        {
            InitializeComponent();

            _contact = contact;

            Shown += ContactSingleViewForm_Shown;
        }

        private void ContactSingleViewForm_Shown(object sender, EventArgs e)
        {
            ContactIdTextBox.Text = _contact.ContactId.ToString();
            ConactTypeTextBox.Text = _contact.ContactTypeIdentifierNavigation.ContactTitle;
            NameTextBox.Text = $@"{_contact.FirstName} {_contact.LastName}";

            /*
             * Another variable is if we sent a ContactItem as in
             * ContactTestOperations.GetContactsAsync as FirstOrDefault passing
             * the contact identifier all of the following would had been done in
             * for us already.
             */
            OfficePhoneTextBox.Text =
                _contact
                    .ContactDevices
                    .FirstOrDefault(contactDevices => contactDevices.PhoneTypeIdentifier == 3)
                    ?.PhoneNumber ?? "(none)";

            CellPhoneNumber.Text =
                _contact
                    .ContactDevices
                    .FirstOrDefault(contactDevices => contactDevices.PhoneTypeIdentifier == 2)
                    ?.PhoneNumber ?? "(none)";

            HomePhoneTextBox.Text =
                _contact
                    .ContactDevices
                    .FirstOrDefault(contactDevices => contactDevices.PhoneTypeIdentifier == 1)
                    ?.PhoneNumber ?? "(none)";

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
