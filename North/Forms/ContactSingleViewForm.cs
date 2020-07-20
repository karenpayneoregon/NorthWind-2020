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

namespace North.Forms
{
    public partial class ContactSingleViewForm : Form
    {
        private ContactItem _contact;
        public ContactSingleViewForm()
        {
            InitializeComponent();
        }
        public ContactSingleViewForm(ContactItem contact)
        {
            InitializeComponent();

            _contact = contact;

            Shown += ContactSingleViewForm_Shown;
        }

        private void ContactSingleViewForm_Shown(object sender, EventArgs e)
        {
            ContactIdTextBox.Text = _contact.Id.ToString();
            ConactTypeTextBox.Text = _contact.ContactType;
            NameTextBox.Text = _contact.ContactName;
            OfficePhoneTextBox.Text = _contact.OfficePhone;
            CellPhoneNumber.Text = _contact.CellPhone;
            HomePhoneTextBox.Text = _contact.HomePhone;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
