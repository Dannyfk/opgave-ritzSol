using System;
using System.Collections.Generic;
using System.Data;
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


namespace Admin
{
    public partial class DrinksWindow : Window
    {
        DataTable drinksTable = null;
        String selectedDrink = null;
        Byte[] picture = null;
        System.Windows.Forms.OpenFileDialog file = new System.Windows.Forms.OpenFileDialog();

        public DrinksWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            loadTable();
        }

        private void loadTable()
        {
            drinksTable = ritz.Service.Instance.getDrinkTable();
            DGridDrinks.DataContext = drinksTable.DefaultView;
        }

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DGridDrinks.SelectedItem != null)
            {
                DataRowView row = DGridDrinks.SelectedItem as DataRowView;
                try
                {
                    string name = (string)row["Navn"];
                    int price = (int)row["Pris"];
                    tBoxName.Text = name;
                    tBoxPrice.Text = price+"";
                    selectedDrink = name;
                }
                catch (NullReferenceException n)
                {
                    MessageBox.Show(n.Message.ToString());
                }
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (tBoxName.Text != "" && tBoxPrice.Text != "" && picture != null)
            {
                int pris = 0;
                if (int.TryParse(tBoxPrice.Text, out pris))
                {
                    ritz.Service.Instance.createDrink(tBoxName.Text, Convert.ToInt32(tBoxPrice.Text), picture);
                    lblPath.Content = "";
                    clearTBoxes();
                    pris = 0;
                }
            }
            loadTable();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedDrink != null)
            {
                if (picture == null)
                {
                    int pris = 0;
                    if (int.TryParse(tBoxPrice.Text, out pris))
                    {
                        ritz.Service.Instance.updateDrink(selectedDrink, tBoxName.Text, Convert.ToInt32(tBoxPrice.Text));
                        pris = 0;
                    }
                }
                else
                {
                    ritz.Service.Instance.updateDrinkWithPicture(selectedDrink, tBoxName.Text, Convert.ToInt32(tBoxPrice.Text), picture);
                    picture = null;
                }
                selectedDrink = null;
                clearTBoxes();
                lblPath.Content = "";
            }
            loadTable();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedDrink != null)
            {

                ritz.Service.Instance.deleteDrink(tBoxName.Text);
                selectedDrink = null;
                clearTBoxes();
            }
            loadTable();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            file.ShowDialog();
            string path = file.FileName;
            string isPicture = path.Substring(path.Length - 3);
            if (isPicture == "jpg" || isPicture == "png")
            {
                picture = ritz.Service.Instance.GetPhoto(path);
                lblPath.Content = path;
            }
        }

        public void clearTBoxes()
        {
            tBoxName.Text = "";
            tBoxPrice.Text = "";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.Show();
        }
    }
}
