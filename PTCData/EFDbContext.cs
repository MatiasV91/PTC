using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCData
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<Productos> Productos { get; set; }
    }
}
