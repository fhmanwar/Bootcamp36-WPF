using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWPF.Model
{
    [Table("Tb_M_Transaction")]
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public Transaction()
        {

        }

        public Transaction(DateTime orderDate)
        {
            this.OrderDate = orderDate;
        }

        public ICollection<TransactionItem> TransactionItem { get; set; }
    }
}
