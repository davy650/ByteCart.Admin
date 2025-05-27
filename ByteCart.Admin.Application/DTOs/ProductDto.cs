using ByteCart.Admin.Domain.Enum;

namespace ByteCart.Admin.Application.DTOs
{
    public class ProductDto
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
        public string? SupplierName { get; set; }
        public IEnumerable<Guid> Tags { get; set; } = new List<Guid>();
         public IEnumerable<string> TagNames { get; set; } = new List<string>();
        public IEnumerable<Guid> Categories { get; set; } = new List<Guid>();
        public IEnumerable<string> CategoryNames { get; set; } = new List<string>();
        public IEnumerable<Guid> Images { get; set; } = new List<Guid>();
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}