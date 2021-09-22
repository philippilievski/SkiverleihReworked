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
    /// Interaction logic for EditItem.xaml
    /// </summary>
    public partial class EditItem : Window
    {
        DataLogic dataLogic = new DataLogic();
        Item item = new Item();
        public EditItem()
        {
            InitializeComponent();
        }
        public EditItem(Item item)
        {
            InitializeComponent();
            txtBoxTitle.Text = item.Title;
            txtBoxPrice.Text = Convert.ToString(item.Price);
            cmbBoxCategory.ItemsSource = dataLogic.GetCategories();
            cmbBoxStatus.ItemsSource = dataLogic.GetStatuses();
            this.item = item;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            item.Status = (Status)cmbBoxStatus.SelectedItem;
            item.Category = (Category)cmbBoxCategory.SelectedItem;
            item.Title = txtBoxTitle.Text;
            item.Price = Convert.ToInt32(txtBoxPrice.Text);
            dataLogic.UpdateItem(item);
            this.Close();
        }
    }
}
