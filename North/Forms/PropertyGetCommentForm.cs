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
using North.Contexts.Configuration;
using North.Models;

namespace North.Forms
{
    /// <summary>
    /// Get comments for each property where comments
    /// are defined in this case <see cref="CustomersConfiguration"/>
    /// </summary>
    public partial class PropertyGetCommentForm : Form
    {
        public PropertyGetCommentForm()
        {
            InitializeComponent();

            listView1.FullRowSelect = true;
            Shown += PropertyGetCommentForm_Shown;
        }

        private void PropertyGetCommentForm_Shown(object sender, EventArgs e)
        {
            IEntityType entityType = ContactTestOperations.Context.Model.FindEntityType(typeof(Customers));

            IEnumerable<IProperty> properties = entityType.GetProperties();

            foreach (IProperty itemProperty in properties)
            {
                var comment = entityType.FindProperty(itemProperty.Name).GetComment();
                if (string.IsNullOrWhiteSpace(comment))
                {
                    comment = "None";
                }

                listView1.Items.Add(new ListViewItem(new[] { itemProperty.Name, comment }));
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.FocusedItem = listView1.Items[0];
            listView1.Items[0].Selected = true;
            ActiveControl = listView1;
        }
    }
}
