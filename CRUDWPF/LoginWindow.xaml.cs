using CRUDWPF.Context;
using CRUDWPF.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CRUDWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MyContext context = new MyContext();
        Regex alphanumRegex = new Regex("^[a-zA-Z0-9. ]*$");
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var validate = context.Suppliers.Where(x => x.Email.Contains(txtEmail.Text)).SingleOrDefault();
            
            if (txtEmail.Text.Equals("") || txtPass.Password.Equals(""))
            {
                MessageBox.Show("Email or Pass is must be filled");
            }
            else if(validate == null)
            {
                MessageBox.Show("Email not available, you must be register");
            }
            else 
            {
                //if (txtEmail.Text != validate.Email && txtPass.Text != validate.Pass)
                if (txtEmail.Text != validate.Email && txtPass.Password.ToString() != validate.Pass)
                    {
                    MessageBox.Show("Email or Pass is wrong");
                }
                else
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
            }
            
        }
    }
}
