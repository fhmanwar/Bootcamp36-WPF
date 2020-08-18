using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWPF.Model
{
    [Table("Tb_M_Supplier")]
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }

        public Supplier()
        {

        }
        public Supplier(string name, string email, string pass)
        {
            this.Name = name;
            this.Email = email;
            this.Pass = pass;
        }
    }
}
