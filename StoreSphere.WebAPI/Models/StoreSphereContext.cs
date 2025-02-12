using Microsoft.EntityFrameworkCore;

namespace StoreSphere.WebAPI.Models
{
    public class StoreSphereContext : DbContext
    {
        public StoreSphereContext(DbContextOptions<StoreSphereContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints

            // User -> Store (One-to-Many)
            modelBuilder.Entity<Store>()
                .HasOne(s => s.User)
                .WithMany(u => u.Stores)
                .HasForeignKey(s => s.UserID)
                .OnDelete(DeleteBehavior.NoAction); // Disable cascade delete if needed

            // Store -> Address (One-to-Many)
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Store)
                .WithMany(s => s.Addresses)
                .HasForeignKey(a => a.StoreID)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete addresses when store is deleted

            // Store -> Product (One-to-Many)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Store)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.StoreID)
                .OnDelete(DeleteBehavior.NoAction); // Disable cascade delete to avoid multiple cascade paths

            // Brand -> Product (One-to-Many)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandID)
                .OnDelete(DeleteBehavior.NoAction); // Disable cascade delete if needed

            // Store -> Brand (Many-to-One)
            modelBuilder.Entity<Store>()
                .HasOne(s => s.Brand)
                .WithMany(b => b.Stores)
                .HasForeignKey(s => s.BrandID)
                .OnDelete(DeleteBehavior.NoAction); // Disable cascade delete if needed

            // Specify precision and scale for the Price column
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); // 18 total digits, 2 decimal places
        }
    }
}