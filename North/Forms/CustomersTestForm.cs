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

namespace North
{
    public partial class CustomersTestForm : Form
    {
        public CustomersTestForm()
        {
            InitializeComponent();

            CustomersDataGridView.AutoGenerateColumns = false;

            Shown += CustomersTestForm_Shown;
        }

        private async void CustomersTestForm_Shown(object sender, EventArgs e)
        {
            var customerItems = await CustomersTestOperations.GetCustomers();
            CustomersDataGridView.DataSource = customerItems;
        }
    }
}
