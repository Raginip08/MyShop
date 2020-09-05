using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyShop.Core.Models;

namespace MyShop.DataAccess.SQL
{
    public class DataContext: DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Product> products { get; set; }
        public DbSet<ProductCategory> categories { get; set; }
    }
}
