using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using FirstUpSorting.Classes;
using FirstUpSorting.LanguageExtensions;

namespace FirstUpSorting
{
    public partial class Form1 : Form
    {
        private BindingListView<CustomerItem> _customerView;

        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            _customerView = new BindingListView<CustomerItem>(await CustomerOperations.DemonstrationCustomOrdering());
            dataGridView1.DataSource = _customerView;
            dataGridView1.Columns["CustomerIdentifier"].Visible = false;
            dataGridView1.ExpandColumns("Name");
        }
    }
}
