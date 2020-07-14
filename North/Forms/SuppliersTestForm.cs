using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static North.Classes.SuppliersTestOperations;

namespace North.Forms
{
    public partial class SuppliersTestForm : Form
    {
        public SuppliersTestForm()
        {
            InitializeComponent();

            Shown += SuppliersTestForm_Shown;
        }

        private async void SuppliersTestForm_Shown(object sender, EventArgs e)
        {
            var suppliers = await GetSuppliersAsync();

            listView1.BeginUpdate();
            try
            {
                foreach (var supplier in suppliers)
                {
                    listView1.Items.Add(
                        new ListViewItem(supplier.ItemArray)
                        {
                            Tag = supplier.SupplierID
                        }
                    );
                }

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            finally
            {
                listView1.EndUpdate();
            }
            listView1.FocusedItem = listView1.Items[0];
            listView1.Items[0].Selected = true;
        }
    }
}
