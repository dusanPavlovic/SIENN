using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Entities;
using Type = SIENN.DbAccess.Entities.Type;

namespace SIENN.DbAccess
{
    public class SIENNContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Unit> Units { get; set; }

        public SIENNContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(d => new { d.CategoryCode, d.ProductCode });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pd => pd.Product)
                .WithMany(d => d.ProductCategories)
                .HasForeignKey(pd => pd.ProductCode);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pd => pd.Category)
                .WithMany(d => d.ProductCategories)
                .HasForeignKey(pd => pd.CategoryCode);
        }
    }
}