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
using North.Classes;
using North.Contexts;

namespace North.Forms
{
    /// <summary>
    /// Example for self referencing same table for ReportsTo (manager)
    /// </summary>
    public partial class EmployeeTestForm : Form
    {
        public EmployeeTestForm()
        {
            InitializeComponent();

            Shown += EmployeeTestForm_Shown;
        }

        private async void EmployeeTestForm_Shown(object sender, EventArgs e)
        {
            var employeeWithManagers = new List<EmployeeWithManager>();

            await Task.Run(async () =>
            {
                using (var context = new NorthwindContext())
                {
                    employeeWithManagers = await context.Employees
                        .Include(employee => 
                            employee.InverseReportsToNavigation)
                        .Select(emp => new EmployeeWithManager
                        {
                            Id = emp.EmployeeID,
                            TitleOfCourtesy = emp.TitleOfCourtesy,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            BirthDate = emp.BirthDate,
                            ManagerFirstName = emp.ReportsToNavigation.FirstName ?? "(self)",
                            ManagerLastName = emp.ReportsToNavigation.LastName ?? "(self)"
                        }).ToListAsync();

                }
            });

            EmployeeWithManagersDataGridView.DataSource = employeeWithManagers;
        }
    }
}
