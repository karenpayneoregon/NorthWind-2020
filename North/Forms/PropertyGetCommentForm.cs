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
        /// <summary>
        /// In the case of Customers all properties have comments, change to Contacts
        /// which does not have comments for all properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropertyGetCommentForm_Shown(object sender, EventArgs e)
        {
            IEntityType entityType = ContactTestOperations.Context.Model.FindEntityType(typeof(Customers));
            var modelComments = entityType.GetProperties().Select(property => new ModelComment
            {
                Name = property.Name,
                Comment = property.GetComment()
            });

            foreach (var modelComment in modelComments)
            {
                listView1.Items.Add(new ListViewItem(new[] { modelComment.Name, modelComment.Comment ?? "(none)" }));
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.FocusedItem = listView1.Items[0];
            listView1.Items[0].Selected = true;
            ActiveControl = listView1;


        }
    }
}
