using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using RecapProject1.Entities;

namespace RecapProject1
{
    public class NorthwindContext:DbContext
    {
        public DbSet<Product> products {  get; set; }

        public DbSet<Category> categories { get; set; }

    }
}
