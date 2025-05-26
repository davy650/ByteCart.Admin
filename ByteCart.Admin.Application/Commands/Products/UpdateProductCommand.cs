using MediatR;
using ByteCart.Admin.Domain.Enum;

namespace ByteCart.Admin.Application.Commands.Products
{
    public record UpdateProductCommand : IRequest<bool>
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
        public DateTime EndDate { get; set; }
        public Guid SupplierId { get; set; }
        public List<Guid> Tags { get; set; } = new List<Guid>();
        public List<string> NewTagNames { get; set; } = new();
        public List<Guid> Categories { get; set; } = new List<Guid>();
        public List<Guid> Images { get; set; } = new List<Guid>();
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}