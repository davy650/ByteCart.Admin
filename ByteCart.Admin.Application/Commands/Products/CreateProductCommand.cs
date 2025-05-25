using ByteCart.Admin.Domain.Enum;
using MediatR;

namespace ByteCart.Admin.Application.Commands.Products
{
    public record CreateProductCommand : IRequest<Guid>
    {
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
        public IEnumerable<Guid> Tags { get; set; } = new List<Guid>();
        public List<string> NewTagNames { get; set; } = new();
        public IEnumerable<Guid> Categories { get; set; } = new List<Guid>();
        public IEnumerable<Guid> Images { get; set; } = new List<Guid>();
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }
}