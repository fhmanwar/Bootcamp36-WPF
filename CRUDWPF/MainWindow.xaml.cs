using CRUDWPF.Context;
using CRUDWPF.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUDWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GridMain.Children.Add(new UserControlHome());
        }        

        private void ButtonPopUpLogo_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl control = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "menuHome":
                    control = new UserControlHome();
                    GridMain.Children.Add(control);
                    break;

                case "menuSupplier":
                    control = new UserControlSupplier();
                    GridMain.Children.Add(control);
                    break;

                case "menuItem":
                    control = new UserControlItem();
                    GridMain.Children.Add(control);
                    break;

                case "menuTransaction":
                    control = new UserControlTransaction();
                    GridMain.Children.Add(control);
                    break;

                case "menuTransactionItem":
                    control = new UserControlTransactionItem();
                    GridMain.Children.Add(control);
                    break;
                    
                default:
                    break;
            }
        }
    }
}
