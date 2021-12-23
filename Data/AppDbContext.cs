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
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<Category_Product>().HasKey(table => 
                new { table.CategoryId, table.ProductId });

            builder.Entity<Feedback>().HasKey(table => 
                new { table.ProductId, table.UserId });

            builder.Entity<ShoppingCart>().HasKey(table => 
                new { table.ProductId, table.UserId });
        }

    }
}