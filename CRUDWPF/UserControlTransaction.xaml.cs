using CRUDWPF.Context;
using CRUDWPF.Model;
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
    public partial class UserControlTransaction : UserControl
    {
        MyContext context = new MyContext();
        public UserControlTransaction()
        {
            InitializeComponent();
            dtList.ItemsSource = context.Transactions.ToList();
            btnUpdate.IsEnabled = false;
            btnInsert.IsEnabled = true;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var trans = context.Transactions.Find(Convert.ToInt32(txtID.Text));
            trans.OrderDate = txtDatePicker.SelectedDate.Value;
            context.SaveChanges();
            MessageBox.Show("1 row has been update");
            Refresh();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var trans = context.Transactions.Find(Convert.ToInt32(txtID.Text));
            context.Transactions.Remove(trans);
            context.SaveChanges();
            MessageBox.Show("1 row has been delete");
            Refresh();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var filteredData = context.Transactions.Where(Q => Q.Id.ToString().Contains(txtSearch.Text)).ToList(); 
            dtList.ItemsSource = filteredData;
        }

        private void dtList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = dtList.SelectedItem as Transaction;
                txtID.Text = Convert.ToString(data.Id);
                txtDatePicker.SelectedDate = data.OrderDate;
                btnUpdate.IsEnabled = true;
                btnInsert.IsEnabled = false;
            }
            catch (Exception)
            {
                txtID.Text = null;
            }
            
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            //if (txtName.Text.Equals(""))
            if (txtDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Nama Wajib di masukkan");
            }
            else
            {
                var input = new Transaction(txtDatePicker.SelectedDate.Value);
                context.Transactions.Add(input);
                context.SaveChanges();
                MessageBox.Show("Data Berhasil Insert");
            }
            Refresh();
            //txtID.Text = "";
            //txtDatePicker.SelectedDate = null;
            //dtList.SelectedItem = null;
            //dtList.ItemsSource = context.Transactions.ToList();
        }

        private void txtDatePicker_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDatePicker.Text))
            {
                lblStatusName.Content = "*Date Picker Cannot Empty !";
                btnInsert.IsEnabled = false;
            }
            else if (!txtDatePicker.Text.All(char.IsLetterOrDigit))
            {
                lblStatusName.Content = "*Date Picker Must Contain Only Date Format !";
                btnInsert.IsEnabled = false;
            }
            else
            {
                lblStatusName.Content = "";
                btnInsert.IsEnabled = true;
            }
        }

        private void Refresh()
        {
            if (btnUpdate.IsEnabled == true)
            {
                dtList.SelectedItem = null;
                txtID.Text = "";
                txtDatePicker.SelectedDate = null;
                txtSearch.Text = "";
                dtList.ItemsSource = context.Transactions.ToList();
                btnUpdate.IsEnabled = false;
                btnInsert.IsEnabled = true;
            }
            else
            {
                txtID.Text = "";
                txtDatePicker.SelectedDate = null;
                txtSearch.Text = "";
                dtList.SelectedItem = null;
                dtList.ItemsSource = context.Transactions.ToList();
            }
            
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
