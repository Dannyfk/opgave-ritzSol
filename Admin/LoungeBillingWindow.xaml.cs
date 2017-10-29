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
using ritz;

namespace Admin
{
    public partial class LoungeBillingWindow : Window
    {
        public LoungeBillingWindow()
        {
            InitializeComponent();

            cBoxRoomNumbers.ItemsSource = ritz.Service.getRoomNumbers();
            dataGrid.ItemsSource = ritz.Service.getDataTable("select itemName as 'Drikkevare:', billedRoomNumber as 'Værelses nummer', purchased as 'Købt:' from loungeBilling").DefaultView;
        }

        private void cBoxRoomNumbers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cBoxRoomNumbers.SelectedValue == " ")
            {
                // let's the btn do the work
            }
            else if (cBoxRoomNumbers.SelectedValue == "All rooms")
            {
                dataGrid.ItemsSource = ritz.Service.getDataTable("select itemName as 'Drikkevare:', billedRoomNumber as 'Værelses nummer', purchased as 'Købt:' from loungeBilling").DefaultView;
            }
            else
            {
                int roomNum = Convert.ToInt32(cBoxRoomNumbers.SelectedValue);
                dataGrid.ItemsSource =
                    ritz.Service.getDataTable("SELECT lbID, billedRoomNumber as 'Værelses nummer', itemName as Drikkevare, purchased as købt from loungeBilling WHERE billedRoomNumber = " + roomNum)
                        .DefaultView;
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.Show();
        }

        private void btnShowDay_Click(object sender, RoutedEventArgs e)
        {

            dataGrid.ItemsSource = ritz.Service.getDataTable("select itemName as 'Drikkevare:' , COUNT(itemName) as 'Mængde:' from loungeBilling where purchased > GETDATE()-1 group by itemName").DefaultView;
            cBoxRoomNumbers.SelectedIndex = Service.getRoomNumbers().Count - 1;
        }

        private void btnShowWeek_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = ritz.Service.getDataTable("select itemName as 'Drikkevare:' , COUNT(itemName) as 'Mængde:' from loungeBilling where purchased > GETDATE()-7 group by itemName").DefaultView;
            cBoxRoomNumbers.SelectedIndex = Service.getRoomNumbers().Count - 1;

        }

        private void btnShowMonth_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = ritz.Service.getDataTable("select itemName as 'Drikkevare:' , COUNT(itemName) as 'Mængde:' from loungeBilling where purchased > GETDATE()-30 group by itemName").DefaultView;
            cBoxRoomNumbers.SelectedIndex = Service.getRoomNumbers().Count - 1;

        }

    }
}
