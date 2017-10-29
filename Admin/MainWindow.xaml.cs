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

namespace Admin
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDrink_Click(object sender, RoutedEventArgs e)
        {
            DrinksWindow drinksWindow = new DrinksWindow();
            drinksWindow.Show();
            this.Hide();
        }

        private void btnStock_Click(object sender, RoutedEventArgs e)
        {
            StockWindow stockWindow = new StockWindow();
            stockWindow.Show();
            this.Hide();
        }

        private void btnBilling_Click(object sender, RoutedEventArgs e)
        {
            LoungeBillingWindow loungeBillingWindow = new LoungeBillingWindow();
            loungeBillingWindow.Show();
            this.Hide();
        }
    }
}
