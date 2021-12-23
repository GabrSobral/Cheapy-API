using Microsoft.EntityFrameworkCore;
using Cheapy_API.Models;

namespace Cheapy_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Category_Product> CategoriesProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<Category_Product>().HasKey(table => 
                new { table.CategoryId, table.ProductId });
        }

    }
}