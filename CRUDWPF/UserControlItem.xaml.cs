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
using System.Data.Entity;

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
            dtList.ItemsSource = context.Items.ToList();
            //Combo_item.ItemsSource = context.Suppliers.Select(x => x.Name).ToList();

            //Combo_item.ItemsSource = context.Items.Include(x => x.Supplier).ToList();
            var item = context.Suppliers.ToList();
            Combo_item.ItemsSource = item;
            Combo_item.DisplayMemberPath = "Name";
            Combo_item.SelectedValuePath = "Id";


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
                Combo_item.SelectedValue = data.Supplier.Id;
                btnUpdate.IsEnabled = true;
                btnInsert.IsEnabled = false;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var filteredData = context.Items.Where(Q => Q.Id.ToString().Contains(txtSearch.Text) || Q.Name.Contains(txtSearch.Text)).ToList(); 
            dtList.ItemsSource = filteredData;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Equals("") || Combo_item.SelectedValue == null)
            {
                MessageBox.Show("Nama Wajib di masukkan");
            }
            else
            {
                var getId = context.Suppliers.Find(Convert.ToInt32(Combo_item.SelectedValue));
                var input = new Item(txtName.Text,Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtStock.Text), getId.Id);
                context.Items.Add(input);
                context.SaveChanges();
                MessageBox.Show("Data Berhasil Insert");
            }
            Refresh();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("Nama Wajib di masukkan");
            }
            else
            {
                var getId = context.Items.Find(Convert.ToInt32(txtID.Text));
                getId.Name = txtName.Text;
                getId.Price = Convert.ToInt32(txtPrice.Text);
                getId.Stock = Convert.ToInt32(txtStock.Text);
                getId.Supplier_Id = Convert.ToInt32(Combo_item.SelectedValue);
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
                var getId = context.Items.Find(Convert.ToInt32(txtID.Text));
                context.Items.Remove(getId);
                context.SaveChanges();
                MessageBox.Show("Data Berhasil Delete");
            }
            Refresh();
        }

        private void Combo_item_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Refresh()
        {
            if (btnUpdate.IsEnabled == true)
            {
                dtList.SelectedItem.Equals("");
                txtID.Text = "";
                txtName.Text = "";
                txtPrice.Text = null;
                txtStock.Text = null;
                Combo_item.SelectedValue = null;
                txtSearch.Text = "";
                dtList.ItemsSource = context.Items.ToList();
                btnUpdate.IsEnabled = false;
                btnInsert.IsEnabled = true;
            }
            else
            {
                txtID.Text = "";
                txtName.Text = "";
                txtPrice.Text = null;
                txtStock.Text = null;
                Combo_item.SelectedValue = null;
                txtSearch.Text = "";
                dtList.SelectedItem = null;
                dtList.ItemsSource = context.Items.ToList();
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
