using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace WpfApp1
{
    class ApplicationContext : DbContext
    {
        public DbSet<user> users { get; set; }

        //public ApplicationContext() : base("DefaultConnection") { }
        public ApplicationContext() : base("DefaultConnection") { }
    }
}
