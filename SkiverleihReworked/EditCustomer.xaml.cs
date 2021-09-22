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
using System.Windows.Shapes;

namespace SkiverleihReworked
{
    /// <summary>
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        DataLogic dataLogic = new DataLogic();
        Customer customer = new Customer();
        public EditCustomer()
        {
            InitializeComponent();
        }
        public EditCustomer(Customer customer)
        {
            InitializeComponent();
            txtBoxFirstname.Text = customer.Firstname;
            txtBoxLastname.Text = customer.Lastname;
            datePickerBirthday.SelectedDate = customer.DateOfBirth;
            this.customer = customer;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            customer.Firstname = txtBoxFirstname.Text;
            customer.Lastname = txtBoxLastname.Text;
            customer.DateOfBirth = datePickerBirthday.SelectedDate ?? DateTime.Now;
            dataLogic.UpdateCustomer(customer);
            this.Close();
        }
    }
}
