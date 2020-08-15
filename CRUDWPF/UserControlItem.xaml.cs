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
    /// Interaction logic for UserControlItem.xaml
    /// </summary>
    public partial class UserControlItem : UserControl
    {
        MyContext context = new MyContext();
        public UserControlItem()
        {
            InitializeComponent();
            dtList.ItemsSource = context.Suppliers.ToList();
            btnUpdate.IsEnabled = false;
            btnInsert.IsEnabled = true;
        }

        private void dtList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtList.SelectedItem != null)
            {
                var data = dtList.SelectedItem as Item;
                txtID.Text = Convert.ToString(data.Id);
                txtName.Text = data.Name;
                txtPrice.Text = Convert.ToString(data.Price);
                txtStock.Text = Convert.ToString(data.Stock);
                txtStock.Text = Convert.ToString(data.Stock);
                btnUpdate.IsEnabled = true;
                btnInsert.IsEnabled = false;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var filteredData = context.Items.Where(Q => Q.Id.ToString().Contains(txtSearch.Text) || Q.Name.Contains(txtSearch.Text)).ToList(); ;
            dtList.ItemsSource = filteredData;
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
            //    //if (txtName.Text.Equals(""))
            //    if (txtName.Text == "")
            //    {
            //        MessageBox.Show("Nama Wajib di masukkan");
            //    }
            //    else
            //    {
            //        var input = new Item(txtName.Text,);
            //        context.Suppliers.Add(input);
            //        context.SaveChanges();
            //        MessageBox.Show("Data Berhasil Insert");
            //    }

            //    txtID.Text = "";
            //    txtName.Text = "";
            //    dtList.SelectedItem = null;
            //    dtList.ItemsSource = context.Suppliers.ToList();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //    if (txtID.Text.Equals(""))
            //    {
            //        MessageBox.Show("Nama Wajib di masukkan");
            //    }
            //    else
            //    {
            //        var getId = context.Suppliers.Find(Convert.ToInt32(txtID.Text));
            //        getId.Name = txtName.Text;
            //        context.SaveChanges();
            //        MessageBox.Show("Data Berhasil Update");
            //    }
            //    dtList.SelectedItem.Equals("");
            //    txtID.Text = "";
            //    txtName.Text = "";
            //    dtList.ItemsSource = context.Suppliers.ToList();
            //    btnUpdate.IsEnabled = false;
            //    btnInsert.IsEnabled = true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //    if (txtID.Text.Equals(""))
            //    {
            //        MessageBox.Show("Nama Wajib di masukkan");
            //    }
            //    else
            //    {
            //        var getId = context.Suppliers.Find(Convert.ToInt32(txtID.Text));
            //        context.Suppliers.Remove(getId);
            //        context.SaveChanges();
            //        MessageBox.Show("Data Berhasil Delete");
            //    }
            //    dtList.SelectedItem.Equals("");
            //    txtID.Text = "";
            //    txtName.Text = "";
            //    dtList.ItemsSource = context.Suppliers.ToList();
            //    btnUpdate.IsEnabled = false;
            //    btnInsert.IsEnabled = true;
        }


    }
}
