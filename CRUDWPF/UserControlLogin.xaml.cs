using CRUDWPF.Context;
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

namespace CRUDWPF
{
    /// <summary>
    /// Interaction logic for UserControlLogin.xaml
    /// </summary>
    public partial class UserControlLogin : UserControl
    {
        MyContext context = new MyContext();
        public UserControlLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserControl control = null;
            GridMain.Children.Clear();

            var checkLogin = context.Suppliers.Where(x => x.Name.Contains(txtEmail.Text)).ToList();
            if (checkLogin.Equals(""))
            {
                MessageBox.Show("Email or Pass is wrong");
            }
            else
            {
                control = new UserControlHome();
                GridMain.Children.Add(control);
            }
        }
    }
}
