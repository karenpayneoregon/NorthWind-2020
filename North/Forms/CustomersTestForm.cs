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

namespace North
{
    public partial class CustomersTestForm : Form
    {
        private BindingSource _bindingSource = new BindingSource();
        public CustomersTestForm()
        {
            InitializeComponent();

            CustomersDataGridView.AutoGenerateColumns = false;

            Shown += CustomersTestForm_Shown;
        }

        private async void CustomersTestForm_Shown(object sender, EventArgs e)
        {
            _bindingSource.DataSource = await CustomersTestOperations.GetCustomersAsync();
            CustomersDataGridView.DataSource = _bindingSource;
        }

        private void CurrentButton_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null) return;

            var current = _bindingSource.CurrentCustomerItem();
            MessageBox.Show($"{current.CompanyName}\n{current.ContactTitle}\n{current.ContactName}");
        }
    }
}
