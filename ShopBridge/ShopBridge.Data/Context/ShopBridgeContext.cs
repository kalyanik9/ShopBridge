using ShopBridge.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Data.Context
{
    public class ShopBridgeDbContext : DbContext
    {
        public ShopBridgeDbContext():base("ShopBridgeDb")
        {

        }
        public DbSet<Product> ProductsList { get; set; }
        public DbSet<ProductCategory> ProductCategoryList { get; set; }
    }
}
