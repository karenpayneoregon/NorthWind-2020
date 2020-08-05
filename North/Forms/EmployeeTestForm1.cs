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
    public partial class EmployeeTestForm1 : Form
    {
        public EmployeeTestForm1()
        {
            InitializeComponent();
        }

        private void AllEmployeeButton_Click(object sender, EventArgs e)
        {
            var employees = 
                EmployeeTestOperations.AllEmployees();

            Console.WriteLine();
        }
    }
}
