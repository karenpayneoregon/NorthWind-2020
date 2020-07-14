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
    public partial class CountryTestForm : Form
    {
        public CountryTestForm()
        {
            InitializeComponent();
            Shown += CountryTestForm_Shown;
        }

        private void CountryTestForm_Shown(object sender, EventArgs e)
        {
            var items = CountryTestOperations.GetCountries();

            foreach (var countryItem in items)
            {
                listView1.Items.Add(
                    new ListViewItem(countryItem.ItemArray)
                    {
                        Tag = countryItem.Id
                    }
                );
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.FocusedItem = listView1.Items[0];
            listView1.Items[0].Selected = true;
        }
    }
}
