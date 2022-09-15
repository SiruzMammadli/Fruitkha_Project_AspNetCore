using Fruitkha.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace Fruitkha.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
