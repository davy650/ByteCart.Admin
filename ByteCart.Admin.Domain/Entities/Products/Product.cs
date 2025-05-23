using ByteCart.Admin.Domain.Common;
using ByteCart.Admin.Domain.Enum;
using ByteCart.Admin.Domain.Entities.Suppliers;

namespace ByteCart.Admin.Domain.Entities.Products
{
    internal class Product : Auditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }
        public int StockQuantity { get; set; }
        public ProductStatus Status { get; set; }
        public DateTime LaunchDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = default!;

        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}