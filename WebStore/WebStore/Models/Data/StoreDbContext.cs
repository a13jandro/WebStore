using System.Data.Entity;

namespace WebStore.Models.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext() : base("StoreDb")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}