using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWPF.Model
{
    [Table("Tb_M_TransactionItem")]
    public class TransactionItem
    {
        [Key]
        public long Id { get; set; }
        public int Quantity { get; set; }

        [Required]
        public Item Item { get; set; }
        [Required]
        public Transaction Transaction { get; set; }

        public TransactionItem()
        {

        }

        public TransactionItem (int quantity)
        {
            this.Quantity = quantity;
        }

        public TransactionItem(int quantity, Item item, Transaction transaction) :
            this(quantity)
        {
            this.Item = item;
            this.Transaction = transaction;
        }
    }
}
