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

namespace ritz
{
    public partial class RoomNumberWindow : Window
    {
        List<String> cart;
        MainWindow previousWindow;
        public RoomNumberWindow(List<String> cart, MainWindow previousWindow)
        {
            InitializeComponent();

            this.cart = cart;
            cBoxRoomNumberList.ItemsSource = Service.getRoomNumbersAsInt();
            this.previousWindow = previousWindow;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (cBoxRoomNumberList.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Er du sikker på at du vil færdiggøre dette køb?", "Spørgsmål", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    this.Close();
                }
                else
                {
                    int id = (int)cBoxRoomNumberList.SelectedValue;
                    List<String> drinks = new List<string>();
                    Boolean error = false;
                    List<String> receipt = Service.buyRoom(cart, id);
                    this.Close();
                    foreach (String s in cart)
                    {
                        Boolean b = Service.Instance.fridgeAlarm(s);
                        if (b == true)
                        {
                            if (!drinks.Contains(s))
                            {
                                drinks.Add(s);
                            }
                            error = true;
                        }
                    }
                    if (error == true)
                    {
                        var errorMessage = string.Join(Environment.NewLine, drinks);
                        MessageBox.Show("Admin popup på en anden computer" + Environment.NewLine + "De følgene drinks er udsolgt" + Environment.NewLine + errorMessage);
                    }
                    var message = string.Join(Environment.NewLine, receipt);
                    MessageBox.Show("Bon:"+Environment.NewLine +message);

                    previousWindow.clearCart();
                    previousWindow.LoadRefrigerator();
                }
            }
        }
    }
}
