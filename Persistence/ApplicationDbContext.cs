using CQRSProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.Persistence
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().HasData(
                new Product("iPhone 15 Pro", "Apple's latest flagship smartphone with a ProMotion display and improved cameras", 999.99m),
                new Product("Dell XPS 15", "Dell's high-performance laptop with a 4K InfinityEdge display", 1899.99m),
                new Product("Sony WH-1000XM4", "Sony's top-of-the-line wireless noise-canceling headphones", 349.99m)
            );
        }
    }
}
