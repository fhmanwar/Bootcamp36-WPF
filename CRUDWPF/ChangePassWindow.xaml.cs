using Bcrypt = BCrypt.Net.BCrypt;
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
using System.Windows.Shapes;
using CRUDWPF.Model;

namespace CRUDWPF
{
    /// <summary>
    /// Interaction logic for ChangePassWindow.xaml
    /// </summary>
    public partial class ChangePassWindow : Window
    {
        MyContext context = new MyContext();
        public ChangePassWindow()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (txtPass.Password.Equals(""))
            {
                MessageBox.Show("Email or Pass is must be filled");
            }
            else if (txtRePass.Password.ToString() != txtPass.Password.ToString())
            {
                MessageBox.Show("Your Password not same");
            }
            else
            {
                var validate = context.Suppliers.Where(x => x.Email.Contains(getEmail.Text)).SingleOrDefault();
                var bcrypt = Bcrypt.HashPassword(txtPass.Password);
                var getId = context.Suppliers.Find(Convert.ToInt32(validate.Id));
                getId.Name = validate.Name;
                getId.Email = validate.Email;
                getId.Pass = bcrypt;
                getId.Guid = "";
                context.SaveChanges();
                MessageBox.Show("Change Password Successfully");

                LoginWindow login = new LoginWindow();
                login.Show();
                this.Close();
            }
        }
    }
}
