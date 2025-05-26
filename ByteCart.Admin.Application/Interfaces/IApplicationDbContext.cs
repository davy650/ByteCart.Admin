using ByteCart.Admin.Domain.Entities.Products;
using ByteCart.Admin.Domain.Entities.Suppliers;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;


namespace ByteCart.Admin.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<Category> Categories { get; }
        DbSet<Supplier> Suppliers { get; }
        DbSet<Tag> Tags { get; }
        DbSet<ProductCategory> ProductCategories { get; }
        DbSet<ProductTag> ProductTags { get; }
        DbSet<Image> Images { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        object Set<T>();
    }
}