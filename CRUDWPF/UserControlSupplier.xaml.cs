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
    /// <summary>
    /// Interaction logic for UserControlCreate.xaml
    /// </summary>
    public partial class UserControlSupplier : UserControl
    {
        MyContext context = new MyContext();
        public UserControlSupplier()
        {
            InitializeComponent();
            dtList.ItemsSource = context.Suppliers.ToList();
            btnUpdate.IsEnabled = false;
            btnInsert.IsEnabled = true;
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtName.Text))
            //{
            //    lblStatusName.Content = "*Name Cannot Empty !";
            //    btnInsert.IsEnabled = false;
            //}
            //else if (!txtName.Text.All(char.IsLetterOrDigit))
            //{
            //    lblStatusName.Content = "*Name Must Contain Only number and text !";
            //    btnInsert.IsEnabled = false;
            //}
            //else
            //{
            //    lblStatusName.Content = "";
            //    btnInsert.IsEnabled = true;
            //}
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            //if (txtName.Text.Equals(""))
            if (txtName.Text == "")
            {
                MessageBox.Show("Nama Wajib di masukkan");
            }
            else
            {
                var input = new Supplier(txtName.Text,txtEmail.Text, txtPass.Text);
                context.Suppliers.Add(input);
                context.SaveChanges();
                MessageBox.Show("Data Berhasil Insert");
            }

            Refresh();
        }

        private void dtList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtList.SelectedItem != null)
            {
                var item = dtList.SelectedItem as Supplier;
                txtID.Text = Convert.ToString(item.Id);
                txtName.Text = item.Name;
                btnUpdate.IsEnabled = true;
                btnInsert.IsEnabled = false;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("Nama Wajib di masukkan");
            }
            else
            {
                var getId = context.Suppliers.Find(Convert.ToInt32(txtID.Text));
                getId.Name = txtName.Text;
                context.SaveChanges();
                MessageBox.Show("Data Berhasil Update");
            }
            Refresh();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("Nama Wajib di masukkan");
            }
            else
            {
                var getId = context.Suppliers.Find(Convert.ToInt32(txtID.Text));
                context.Suppliers.Remove(getId);
                context.SaveChanges();
                MessageBox.Show("Data Berhasil Delete");
            }
            Refresh();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var filteredData = context.Suppliers.Where(Q => Q.Id.ToString().Contains(txtSearch.Text) || Q.Name.Contains(txtSearch.Text)).ToList();
            dtList.ItemsSource = filteredData;
        }

        public void Refresh ()
        {
            if (btnUpdate.IsEnabled == true)
            {
                dtList.SelectedItem.Equals("");
                txtID.Text = "";
                txtName.Text = "";
                txtEmail.Text = "";
                txtPass.Text = "";
                txtSearch.Text = "";
                dtList.ItemsSource = context.Suppliers.ToList();
                btnUpdate.IsEnabled = false;
                btnInsert.IsEnabled = true;
            }
            else
            {
                txtID.Text = "";
                txtName.Text = "";
                txtEmail.Text = "";
                txtPass.Text = "";
                txtSearch.Text = "";
                dtList.SelectedItem = null;
                dtList.ItemsSource = context.Suppliers.ToList();
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
