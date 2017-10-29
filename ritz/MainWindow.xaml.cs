using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;

namespace ritz
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        bool _playing = false;
        private List<String> cart = new List<string>();
        private List<Image> images = Service.getDrinks();
        public MainWindow()
        {
            InitializeComponent();
            LoadRefrigerator();

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(rectangle_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
            timer.Start();

            rect.Opacity = 1;
        }

        public void LoadRefrigerator()
        {
            RefrigeratorPanel.Children.Clear();
            images = Service.getDrinks();
            foreach (Image i in images)
            {
                i.ToolTip = i.Tag;
                i.MouseLeftButtonUp += image_MouseLeftButtonUp;
                RefrigeratorPanel.Children.Add(i);
            }
        }

        public void LoadCart()
        {
            foreach (String s in cart)
            {
                Image image = new Image();
                Uri uri = new Uri(s);
                ImageSource imgSource = new BitmapImage(uri);

                image.Source = imgSource;
                image.Height = 50;
                image.Width = 50;
                image.Tag = s;               
            }
        }
        private void image_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            
            Image imageC = (Image)sender;
            String s = (String)imageC.Tag;
          
            cart.Add(s);

            foreach (Image i in images)
            {
                if (i.Tag == s)
                {
                    imageC = new Image();
                    imageC.Source = i.Source;
                    imageC.Tag = i.Tag;
                    imageC.MouseLeftButtonUp += imageC_MouseLeftButtonUp;
                    
                    CartPanel.Children.Add(imageC);
                }
            }
            lblTotal.Content = Service.getTotalPrice(cart); 
       }


        private void imageC_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            Image imageC = (Image)sender;
            String s = (String)imageC.Tag;
            cart.Remove(s);
            
            CartPanel.Children.Remove(imageC);

            lblTotal.Content = Service.getTotalPrice(cart);         
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        public void clearCart()
        {
            CartPanel.Children.Clear();
            cart.Clear();
            lblTotal.Content = Service.getTotalPrice(cart);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            clearCart(); 
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            RoomNumberWindow numWin = new RoomNumberWindow(cart, this);
            numWin.ShowDialog();
        }

        private void btnCash_Click(object sender, RoutedEventArgs e)
        {
            if (cart.Count != 0)
            {
                List<String> drinks = new List<string>();
                List<String> receipt = Service.buyCash(cart);
                Boolean error = false;

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
                MessageBox.Show("Bon:" + Environment.NewLine + message);
                clearCart();
                LoadRefrigerator();
            }
        }
        private void rectangle_Tick(object sender, EventArgs e)
        {
            if (!_playing)
            {
                mE.Source = new Uri("C:\\Windows\\Media\\tada.wav");
                mE.Play();
                _playing = true;
            }
            if (rect.Opacity > 0)
            {
                rect.Opacity = rect.Opacity - 0.01;

            }
            if (rect.Opacity < 0)
            {
                timer.Stop();
                grid.Children.Remove(rect);
            }
        }
    }
}