using ByteCart.Admin.Application.Interfaces;
using ByteCart.Admin.Domain.Entities.Products;
using ByteCart.Admin.Domain.Entities.Suppliers;
using Microsoft.EntityFrameworkCore;

namespace ByteCart.Admin.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });
            modelBuilder.Entity<ProductTag>()
                .HasKey(pt => new { pt.ProductId, pt.TagId });
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId);
            modelBuilder.Entity<Category>()
                .HasMany(c => c.SubCategories)
                .WithOne(c => c.ParentCategory)
                .HasForeignKey(c => c.ParentCategoryId)
                .IsRequired(false);
        }
        public DbSet<Product> Products => Set<Product>();

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<Supplier> Suppliers => Set<Supplier>();

        public DbSet<Tag> Tags => Set<Tag>();

        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();

        public DbSet<ProductTag> ProductTags => Set<ProductTag>();

        public DbSet<Image> Images => Set<Image>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }

     
}