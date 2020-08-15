using CRUDWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWPF.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("CRUDWPF") { }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
