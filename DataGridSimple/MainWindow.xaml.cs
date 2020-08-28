using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using NorthStockConfiguration;
using NorthStockConfiguration.Classes;
using static System.Windows.WindowStartupLocation;
using static DataGridSimple.Classes.CommonDialogs;

namespace DataGridSimple
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WindowStartupLocation = CenterScreen;
        }

        /// <summary>
        /// Load employees, note in xaml that only a select few properties are loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var employeeList = await EmployeeOperations.GetEmployeeListAsync();
            EmployeeGrid.ItemsSource = employeeList;
        }
        /// <summary>
        /// Provides ability to update current employee in the data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCurrent_OnClick(object sender, RoutedEventArgs e)
        {
            if (Question("Update current employee?"))
            {
                var employee = EmployeeGrid.SelectedItem as Employees;
                if (!EmployeeOperations.Update(employee))
                {
                    MessageBox.Show("Update failed");
                }
            }

        }
        /// <summary>
        /// Remove row (incomplete and not MVVM)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCurrentRemove_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = EmployeeGrid.SelectedItem;

            if (selectedItem != null)
            {
                var employee = EmployeeGrid.SelectedItem as Employees;

                if (Question($"Remove {employee.TitleOfCourtesy} {employee.LastName} employee?"))
                {
                    var employeeList = (List<Employees>)EmployeeGrid.ItemsSource;

                    
                    EmployeeGrid.Items.Refresh();
                    employeeList.Remove(employee);
                    EmployeeGrid.Focus();

                }
            }
            else
            {
                MessageBox.Show("No current employee");
            }
        }
        /// <summary>
        /// Close application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        /// <summary>
        /// Focus DataGrid, highlight first row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            EmployeeGrid.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            EmployeeGrid.Focus();
        }


    }
}
