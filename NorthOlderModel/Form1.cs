using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NorthOlderModel.Classes;
using NorthOlderModel.Context;
using NorthOlderModel.Models;

namespace NorthOlderModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            var modelCommentList = new List<ModelComment>();
            var customers = new List<Customers>();

            using (var context = new NorthwindContext())
            {
                customers = context.Customers
                    .Where(customer => !string.IsNullOrWhiteSpace(customer.Region)).ToList();

                dataGridView1.DataSource = customers;
                dataGridView1.ExpandColumns();

                var navigation = dataGridView1.Columns.Cast<DataGridViewColumn>()
                    .FirstOrDefault(x => x.Name.Contains("Navigation"));

                if (navigation != null)
                {
                    dataGridView1.Columns[navigation.Name].Visible = false;
                }

                IEntityType entityType = context.Model.FindEntityType(typeof(Customers));
                modelCommentList = entityType.GetProperties().Select(property => new ModelComment
                {
                    Name = property.Name,
                    Comment = property.GetComment()
                }).ToList();
            }

            foreach (var modelComment in modelCommentList)
            {
                MemberInfo property = typeof(Customers).GetProperty(modelComment.Name);

                if (property.GetCustomAttribute(typeof(DisplayAttribute)) is DisplayAttribute dd)
                {
                    modelComment.DisplayText = dd.Name;
                }
            }

            foreach (var modelComment in modelCommentList)
            {
                dataGridView1.Columns[modelComment.Name].HeaderText = modelComment.Comment;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
