using SkiverleihReworked.Logic;
using SkiverleihReworked.Model;
using System;
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

namespace SkiverleihReworked
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataLogic dataLogic = new DataLogic();
        public MainWindow()
        {
            InitializeComponent();
            dgCustomer.ItemsSource = dataLogic.GetCustomers();
            dgItem.ItemsSource = dataLogic.GetItems();
            dgCustomerItems.ItemsSource = dataLogic.GetCustomerItems();
        }

        private void btnLend_Click(object sender, RoutedEventArgs e)
        {
            if(dgCustomer.SelectedItem == null || dgItem.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer and item");
                return;
            }

            Customer customer = (Customer)dgCustomer.SelectedItem;
            Item item = (Item)dgItem.SelectedItem;
            Status status = item.Status;

            if(item.Status.StatusID == 2)
            {
                MessageBox.Show("Item is unavaliable");
                return;
            }
            else
            {
                dataLogic.AddCustomerItems(customer, item);
            }

            dgCustomerItems.ItemsSource = dataLogic.GetCustomerItems();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            if(dgCustomerItems.SelectedItem == null)
            {
                MessageBox.Show("Select an item please!");
            }
            else
            {
                CustomerItem customerItem = (CustomerItem)dgCustomerItems.SelectedItem;
                dataLogic.ReturnCustomerItem(customerItem);
                customerItem.Item.Status.StatusID = 1;

                dgCustomerItems.ItemsSource = dataLogic.GetCustomerItems();
            }
        }

        private void btnEditCustomers_Click(object sender, RoutedEventArgs e)
        {
            EditCustomer editCustomer = new EditCustomer((Customer)dgCustomer.SelectedItem);
            editCustomer.ShowDialog();
        }

        private void btnEditItems_Click(object sender, RoutedEventArgs e)
        {
            EditItem editItem = new EditItem((Item)dgItem.SelectedItem);
            editItem.ShowDialog();
        }

        private void dgCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer customer = (Customer)dgCustomer.SelectedItem;
            lblFullname.Content = customer.Fullname;
        }

        private void dgItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item item = (Item)dgItem.SelectedItem;
            lblItemTitle.Content = item.Title;
        }
    }
}
