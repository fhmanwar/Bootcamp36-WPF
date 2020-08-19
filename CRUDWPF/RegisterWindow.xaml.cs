using Bcrypt = BCrypt.Net.BCrypt;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        MyContext context = new MyContext();
        LoginWindow login = new LoginWindow();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            var validate = context.Suppliers.Where(x => x.Email.Contains(txtEmail.Text)).SingleOrDefault();
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(txtEmail.Text, regex, RegexOptions.IgnoreCase);
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || txtPass.Password.Equals("") || txtNama.Text.Equals(""))
            {
                MessageBox.Show("Email or Pass or is must be filled");
            }
            else if (!isValid)
            {
                MessageBox.Show("Invalid Email Address");
            }
            else if (txtRePass.Password.ToString() != txtPass.Password.ToString())
            {
                MessageBox.Show("Your Password not same");
            }
            else
            {
                if (validate != null)
                {
                    MessageBox.Show("Email Already Exist");
                }
                else
                {
                    var bcrypt = Bcrypt.HashPassword(txtPass.Password);
                    var input = new Supplier(txtNama.Text, txtEmail.Text, bcrypt.ToString());
                    context.Suppliers.Add(input);
                    context.SaveChanges();
                    MessageBox.Show("Register Successfully");
                    login.Show();
                    this.Close();
                }
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            login.Show();
            this.Close();
        }
    }
}
