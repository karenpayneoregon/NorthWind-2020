using System;
using System.Windows.Forms;
using North.Classes;

namespace North.Forms
{
    /// <summary>
    /// Important note, keep in mind coding here is to test the classes function
    /// properly. For a production project this all would be done differently.
    /// </summary>
    public partial class OrdersTestForm : Form
    {
        private readonly BindingSource _ordersBindingSource = new BindingSource();
        private readonly BindingSource _orderDetailsBindingSource = new BindingSource();
        public OrdersTestForm()
        {
            InitializeComponent();

            Shown += OrdersTestForm_Shown;
            OrderDataGridView.AutoGenerateColumns = false;
        }

        private async void OrdersTestForm_Shown(object sender, EventArgs e)
        {
            var customers = await CustomersTestOperations.GetCustomerItemsForComboBox();
            CustomersComboBox.DataSource = customers;
            GetOrdersForCustomer();
            CustomersComboBox.SelectedIndexChanged += CustomersComboBox_SelectedIndexChanged;
            _ordersBindingSource.PositionChanged += _ordersBindingSource_PositionChanged;
        }

        private void _ordersBindingSource_PositionChanged(object sender, EventArgs e)
        {
            
            _orderDetailsBindingSource.DataSource =
                OrdersTestOperation.GetOrderDetailItems(((OrderItem) _ordersBindingSource.Current).OrderID);

            OrderDetailsDataGridView.DataSource = _orderDetailsBindingSource;
        }

        private void CustomersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOrdersForCustomer();
        }

        private void GetOrdersForCustomer()
        {
            var currentCustomerIdentifier = ((CustomerItem) CustomersComboBox.SelectedItem).CustomerIdentifier;
            _ordersBindingSource.DataSource = OrdersTestOperation.GetCustomerOrders(currentCustomerIdentifier);

            OrderCountLabel.Text = $"Order count: {_ordersBindingSource.Count}";
            OrderDataGridView.DataSource = _ordersBindingSource;

            if (_ordersBindingSource.Count == 0)
            {
                _orderDetailsBindingSource.DataSource = null;
                OrderDetailsDataGridView.DataSource = null;
            }
            else
            {
                _orderDetailsBindingSource.DataSource = OrdersTestOperation
                    .GetOrderDetailItems(((OrderItem) _ordersBindingSource.Current).OrderID);
            }

            OrderDetailsDataGridView.DataSource = _orderDetailsBindingSource;
        }
    }
}
