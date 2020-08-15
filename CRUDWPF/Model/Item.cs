using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWPF.Model
{
    [Table("Tb_M_Item")]
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }

        public int Supplier_Id { get; set; }

        [ForeignKey("Supplier_Id")]
        public virtual Supplier Supplier { get; set; }

        public Item()
        {

        }
        public Item(string name, int price, int stock, int supp)
        {
            this.Name = name;
            this.Price = price;
            this.Stock = stock;
            this.Supplier_Id = supp;
        }
    }
}
