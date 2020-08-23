using Bcrypt = BCrypt.Net.BCrypt;
using CRUDWPF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Interaction logic for ForgotWindow.xaml
    /// </summary>
    public partial class ForgotWindow : Window
    {
        MyContext context = new MyContext();
        //Guid g = Guid.NewGuid();
        string mail = "testingsmtp82@gmail.com";
        string pass = "ASDqwe123";
        SmtpClient client = new SmtpClient();
        public ForgotWindow()
        {
            InitializeComponent();
        }

        private void btnForgot_Click(object sender, RoutedEventArgs e)
        {
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(mail, pass);

            var guid = Guid.NewGuid();
            var validate = context.Suppliers.Where(x => x.Email.Contains(txtEmail.Text)).SingleOrDefault();
            var fill = "Hi "+validate.Name+"\n\n"
                      +"Try this Password to get into reset password: \n"
                      + guid
                      + "\n\nThank You";

            MailMessage mm = new MailMessage("donotreply@domain.com", txtEmail.Text, "Forgot Email", fill);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mm);

            var bcrypt = Bcrypt.HashPassword(guid.ToString());
            var getId = context.Suppliers.Find(Convert.ToInt32(validate.Id));
            getId.Name = validate.Name;
            getId.Email = validate.Email;
            getId.Pass = "";
            getId.Guid = Bcrypt.HashPassword(bcrypt);
            context.SaveChanges();
            MessageBox.Show("Check Your Email");
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}
