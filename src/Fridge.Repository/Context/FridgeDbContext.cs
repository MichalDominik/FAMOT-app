using Microsoft.EntityFrameworkCore;
using Fridge.Service.Models;

namespace Fridge.Repository.Context
{
    public class FridgeDbContext : DbContext
    {
        public FridgeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
