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
        public DateTime? EndDate { get; set; }
        public Guid SupplierId { get; set; }
        public IEnumerable<Guid> Tags { get; set; } = new List<Guid>();
        public List<string> NewTagNames { get; set; } = new();
        public IEnumerable<Guid> Categories { get; set; } = new List<Guid>();
        public IEnumerable<Guid> Images { get; set; } = new List<Guid>();
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }

    // public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    // {
    //     private readonly IProductRepository _productRepository;

    //     public UpdateProductCommandHandler(IProductRepository productRepository)
    //     {
    //         _productRepository = productRepository;
    //     }

    //     public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    //     {
    //         var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
    //         if (product == null)
    //             return false;

    //         product.Name = request.Name;
    //         product.SKU = request.SKU;
    //         product.Description = request.Description;
    //         product.Price = request.Price;
    //         product.CostPrice = request.CostPrice;
    //         product.StockQuantity = request.StockQuantity;
    //         product.Status = request.Status;
    //         product.LaunchDate = request.LaunchDate;
    //         product.EndDate = request.EndDate;
    //         product.SupplierId = request.SupplierId;
    //         product.Tags = request.Tags.ToList();
    //         product.Categories = request.Categories.ToList();
    //         product.Images = request.Images.ToList();
    //         product.ModifiedAt = request.ModifiedAt ?? DateTime.UtcNow;
    //         product.ModifiedBy = request.ModifiedBy;

    //         await _productRepository.UpdateAsync(product, cancellationToken);
    //         return true;
    //     }
    // }
}