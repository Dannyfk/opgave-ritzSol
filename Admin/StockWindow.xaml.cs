using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
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
    public partial class StockWindow : Window
    {
        DataTable drinksTable = null;
        public StockWindow()
        {
            InitializeComponent();
            loadTable();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            loadTable();
        }

        private void loadTable()
        {
            drinksTable = ritz.Service.getDrinksStock();
            dataGrid.DataContext = drinksTable.DefaultView;
            colorCells();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < (dataGrid.Items.Count - 1); i++)
            {
                DataRowView drv = (DataRowView)dataGrid.Items[i];
                string name = drv["Navn"].ToString();
                String checkSQLStock = "";
                String checkSQLFridge = "";
                try
                {
                    checkSQLStock = "SELECT onStock FROM drink WHERE name = '" + name + "'";
                    checkSQLFridge = "SELECT inFridge FROM drink WHERE name = '" + name + "'";


                int previousInStock = ritz.Service.executeQueryReturnInt(checkSQLStock);
                int previousInFridge = ritz.Service.executeQueryReturnInt(checkSQLFridge);

                int stock;
                int fridge;
                if (int.TryParse(drv["Lager"].ToString(), out stock))
                {
                    int onStock = (int)drv["Lager"];

                    if (previousInStock <= onStock)
                    {
                        String sql = "UPDATE drink SET onStock = " + onStock + " WHERE name = '" + name + "'";
                        ritz.Service.executeQuery(sql);
                    }
                    else
                    {
                        MessageBox.Show("Værdien i række " + (i + 1) + " var mindre end førværdien. Kun større værdier er tilladt.");
                    }
                }
                if (int.TryParse(drv["Køleskab"].ToString(), out fridge))
                {
                    int inFridge = (int)drv["Køleskab"];

                    if (previousInStock >= (inFridge - previousInFridge))
                    {
                        String sql = "UPDATE drink SET inFridge = " + inFridge + " WHERE name = '" + name + "'";
                        ritz.Service.executeQuery(sql);
                    }
                    else
                    {
                        MessageBox.Show("Tjek dine værdier.");
                    }
                }
                else
                {
                    MessageBox.Show("En ikke tal-værdi er blevet indsat i række " + (i + 1));
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ikke ændre navnet på drikkevaren");
                }
            }
            loadTable();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.Show();
        }

        private void colorCells()
        {
            Style style = (Style)(FindResource("cellStyle"));
            for (int i = 1; i < dataGrid.Columns.Count; i++)
            {
                dataGrid.Columns[i].CellStyle = style;
            }
        }
    }
}
