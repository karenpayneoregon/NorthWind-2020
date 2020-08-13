using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationMocked.Classes;
using ValidationMocked.Validators;

namespace ValidationMocked
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Violate all rules for required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validate1Button_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            var validationResult = ValidationHelper.ValidateEntity(employee);
            if (validationResult.HasError)
            {
                Console.WriteLine(validationResult.ErrorMessageList());
            }
            else
            {
                Console.WriteLine("Call save changes");
            }
        }
        /// <summary>
        /// Violate max length for FirstName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validate2Button_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee()
            {
                LastName = "Payne",
                FirstName = "Karen Karen Karen Karen Karen Karen Karen Karen Karen Karen",
                HireDate = DateTime.Now,
                PersonalEmail = "pk@gmail.com"
            };

            var validationResult = ValidationHelper.ValidateEntity(employee);
            if (validationResult.HasError)
            {
                Console.WriteLine(validationResult.ErrorMessageList());
            }
            else
            {
                Console.WriteLine("Call save changes");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
