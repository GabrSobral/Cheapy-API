using Microsoft.EntityFrameworkCore;
using Cheapy_API.Models;

namespace Cheapy_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) {}

        public DbSet<User> Users { get; set; }
    }
}