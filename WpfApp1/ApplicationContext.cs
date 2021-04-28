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
        public DbSet<input_paints> input_paint { get; set; }
        public DbSet<output_paints> output_paint { get; set; }
        public DbSet<user> users { get; set; }
        

        //public ApplicationContext() : base("DefaultConnection") { }
        public ApplicationContext() : base("DefaultConnection") { }
    }
}
