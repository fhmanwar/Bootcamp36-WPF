using CRUDWPF.Context;
using CRUDWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for UserControlTransactionItem.xaml
    /// </summary>
    public partial class UserControlTransactionItem : UserControl
    {
        private MyContext _context = new MyContext();

        static Regex numOnly = new Regex("^[0-9]+$");
        private static bool IsTextAllowed(string text)
        {
            return numOnly.IsMatch(text);
        }

        private List<TransactionItem> _GetAll ()
        {
            return _context.TransactionItems
                .Include(a => a.Item)
                .Include(b => b.Transaction)
                .ToList();
        }

        private void CallTable(List<TransactionItem> obj)
        {
            dataTI.ItemsSource = obj;

            if (obj.Count() == 0)
            {
                emptyData.Visibility = Visibility.Visible;
            }
            else
            {
                emptyData.Visibility = Visibility.Hidden;
            }
        }

        private void Clear()
        {
            searchBox.Clear();
            id.Text = "";
            itemBox.SelectedIndex = -1;
            itemBox.IsDropDownOpen = false;
            quantityBox.Text = "1";
            transactionBox.SelectedIndex = -1;
            transactionText.Visibility = Visibility.Visible;
            dataTI.UnselectAllCells();
            insertButton.Content = "Insert";
        }

        public UserControlTransactionItem()
        {
            InitializeComponent();

            CallTable(_GetAll());

            var itemList = _context.Items.ToList();
            itemBox.ItemsSource = itemList;
            itemBox.DisplayMemberPath = "Name";
            itemBox.SelectedValuePath = "Id";

            var transactionList = _context.Transactions.ToList();
            transactionBox.ItemsSource = transactionList;
            transactionBox.DisplayMemberPath = "Id";
            transactionBox.SelectedValuePath = "Id";

        }

        private void DataTI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TransactionItem transactionItem = (TransactionItem)dataTI.SelectedItem;
                id.Text = Convert.ToString(transactionItem.Id);
                itemBox.SelectedValue = transactionItem.Item.Id; 
                quantityBox.Text = Convert.ToString(transactionItem.Quantity);
                transactionBox.SelectedValue = transactionItem.Transaction.Id;

                if (!string.IsNullOrWhiteSpace(id.Text))
                {
                    insertButton.Content = "Update";
                }
                else
                {
                    insertButton.Content = "Insert";
                }
           }

            catch (Exception)
            {
                id.Text = "";
            }
            
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt16(id.Text);
            var obj = _context.TransactionItems
                .Include(i => i.Item)
                .Include(t => t.Transaction)
                .Single(c => c.Id == Id);
            MessageBoxResult result = MessageBox.Show("This cannot be undone", "Warning", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show(obj.Item.Name + " With the transaction no " +
                        obj.Transaction.Id + " Has been deleted");
                    _context.TransactionItems.Remove(obj);
                    _context.SaveChanges();
                    CallTable(_GetAll());
                    Clear();
                    break;
                case MessageBoxResult.No:
                    break;

            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filteredData = _context.TransactionItems.Where(i => i.Item.Name.Contains(searchBox.Text)
                || i.Transaction.Id.ToString().Contains(searchBox.Text)).ToList();
            dataTI.ItemsSource = filteredData;

            if (searchBox.Text.Equals(""))
            {
                searchText.Visibility = Visibility.Visible;
            }
            else
            {
                searchText.Visibility = Visibility.Hidden;
            }
        }

        private void ItemBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (String.IsNullOrWhiteSpace(itemBox.Text) /*&& !_context.Items.Any(i => i.Name == itemBox.Text)*/)
            {
                itemBox.SelectedIndex = -1;
                itemText.Visibility = Visibility.Visible;
                var filteredData = _context.Items.ToList();
                itemBox.ItemsSource = filteredData;
                itemBox.DisplayMemberPath = "Name";
                itemBox.SelectedValuePath = "Id";
            }
            else if (!_context.Items.Any(i => i.Name == itemBox.Text))
            {
                itemBox.IsDropDownOpen = true;
                var filteredData = _context.Items.Where(i => i.Name.Contains(itemBox.Text)).ToList(); 
                itemText.Visibility = Visibility.Hidden;
                itemBox.ItemsSource = filteredData;
                itemBox.DisplayMemberPath = "Name";
                itemBox.SelectedValuePath = "Id";
            }

        }

        private void ItemBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.itemBox.SelectedValue = itemBox.SelectedValue;
            itemText.Visibility = Visibility.Hidden;
        }

        private void ButtonUp_Click(object sender, RoutedEventArgs e)
        {
            int plus;
            int init = Convert.ToInt16(quantityBox.Text);

            plus = init + 1;
            if (plus >= 1000)
            {
                plus = 1000;
            }

            quantityBox.Text = Convert.ToString(plus);
        }

        private void ButtonDown_Click(object sender, RoutedEventArgs e)
        {
            int minus;
            int init = Convert.ToInt16(quantityBox.Text);

            minus = init - 1;
            if (minus <= 1)
            {
                minus = 1;
            }

            quantityBox.Text = Convert.ToString(minus);
        }

        private void QuantityBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void QuantityBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(quantityBox.Text))
                {
                    quantityBox.Text = "1";
                }
                else if (Convert.ToInt16(quantityBox.Text) >= 1000)
                {
                    quantityBox.Text = "1000";
                }
            }
            
            catch (Exception)
            {
                quantityBox.Text = "1000";
            }
        }

        private void TransactionBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.transactionBox.SelectedValue = transactionBox.SelectedValue;
            transactionText.Visibility = Visibility.Hidden;

        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            int itemId = Convert.ToInt16(itemBox.SelectedValue);
            var itemObj = _context.Items.Find(itemId);
            int transactionId = Convert.ToInt16(transactionBox.SelectedValue);
            var transactionObj = _context.Transactions.Find(transactionId);
            int quantity = Convert.ToInt16(quantityBox.Text);

            if (String.IsNullOrWhiteSpace(id.Text))
            {
                try
                {
                    var insert = new TransactionItem(quantity, itemObj, transactionObj);
                    _context.TransactionItems.Add(insert);
                    _context.SaveChanges();
                    MessageBox.Show("Data has been inserted.");
                    CallTable(_GetAll());
                    Clear();
                }

                catch (Exception)
                {
                    MessageBox.Show("Error, cannot insert to database");
                    Clear();
                }
                
            }
            else
            {
                int findId = Convert.ToInt16(id.Text);
                itemId = Convert.ToInt16(itemBox.SelectedValue);
                itemObj = _context.Items.Find(itemId);
                transactionId = Convert.ToInt16(transactionBox.Text);
                transactionObj = _context.Transactions.Find(transactionId);

                var update = _context.TransactionItems.Find(findId);
                update.Item = itemObj;
                update.Quantity = Convert.ToInt32(quantityBox.Text);
                update.Transaction = transactionObj;

                MessageBoxResult result = MessageBox.Show("This will be updated", "Warning", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        MessageBox.Show(update.Item.Name + " With the transaction no " +
                            update.Transaction.Id + " Has been Updated");
                        _context.SaveChanges();
                        CallTable(_GetAll());
                        Clear();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
                
            }

        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

    }
}
