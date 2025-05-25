using ByteCart.Admin.Application.Commands.Products;
using ByteCart.Admin.Application.Interfaces;
using ByteCart.Admin.Domain.Entities.Products;
using MediatR;

namespace ByteCart.Admin.Application.Handlers.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                SKU = request.SKU,
                Description = request.Description,
                Price = request.Price,
                CostPrice = request.CostPrice,
                StockQuantity = request.StockQuantity,
                Status = request.Status,
                LaunchDate = request.LaunchDate,
                EndDate = request.EndDate,
                SupplierId = request.SupplierId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = request.CreatedBy
            };

            // tags
            foreach (var tag in request.Tags)
            {
                product.ProductTags.Add(new ProductTag { TagId = tag, ProductId = product.Id });
            }

            // categories
            foreach (var category in request.Categories)
            {
                product.ProductCategories.Add(new ProductCategory { CategoryId = category, ProductId = product.Id });
            }

            // images
            foreach (var image in request.Images)
            {
                product.Images.Add(new Image { Id = image, ProductId = product.Id });
            }

            // new tags
            foreach (var tagName in request.NewTagNames)
            {
                var tag = new Tag { Id = Guid.NewGuid(), Name = tagName };
                product.ProductTags.Add(new ProductTag { Tag = tag, ProductId = product.Id });
                _context.Tags.Add(tag);
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product.Id;
        }
    }
}