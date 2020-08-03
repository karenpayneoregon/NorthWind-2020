using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NorthWithFoldersAnnotations.Models;
using NorthWithFoldersAnnotations.Validators;

namespace AnnotationsDemos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Simple validation, CompanyName is marked as required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerNameRequiredButton_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                Contact = new Contact() {FirstName = "Karen", LastName = "Payne"}
            };

            var validationResult = ValidationHelper.ValidateEntity(customer);

            if (validationResult.HasError)
            {
                var message = validationResult.ErrorMessageList();
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show(@"Valid Customer");
            }

            /*
             * Set company name so we are valid now
             */
            customer.CompanyName = "Some new company";

            validationResult = ValidationHelper.ValidateEntity(customer);

            if (validationResult.HasError)
            {
                var message = validationResult.ErrorMessageList();
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show(@"Valid Customer");
            }

        }
    }
}
