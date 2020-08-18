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

namespace DataGridSimple
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WindowStartupLocation = CenterScreen;
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var employeeList = await EmployeeOperations.GetEmployeeListAsync();
            EmployeeGrid.ItemsSource = employeeList;
        }

        private void ButtonCurrent_OnClick(object sender, RoutedEventArgs e)
        {
            var employee = EmployeeGrid.SelectedItem as Employees;
            if (!EmployeeOperations.Update(employee))
            {
                MessageBox.Show("Update failed");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
