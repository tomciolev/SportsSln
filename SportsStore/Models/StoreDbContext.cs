using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Department> Departments => Set<Department>();
    }
}
