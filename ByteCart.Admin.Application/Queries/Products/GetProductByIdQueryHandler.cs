using ByteCart.Admin.Application.Commands.Products;
using ByteCart.Admin.Application.DTOs;
using ByteCart.Admin.Application.Interfaces;
using ByteCart.Admin.Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ByteCart.Admin.Application.Queries.Products
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryCommand, ProductDto>
    {
        private readonly IApplicationDbContext _context;
        public GetProductByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Handle(GetProductByIdQueryCommand request, CancellationToken cancellationToken)
        {
            IQueryable<Product> query = _context.Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .Include(p => p.Images)
                .Include(p => p.Supplier)
                .Where(p => p.Id == request.Id);

            var product = await query.FirstAsync(cancellationToken);

            if (product == null)
            {
                throw new Exception($"Product {request.Id} not found");
            }

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                SKU = product.SKU,
                Description = product.Description,
                Price = product.Price,
                CostPrice = product.CostPrice,
                StockQuantity = product.StockQuantity,
                Status = product.Status,
                LaunchDate = product.LaunchDate,
                EndDate = product.EndDate,
                SupplierId = product.SupplierId,
                CreatedAt = product.CreatedAt,
                CreatedBy = product.CreatedBy,
                ModifiedAt = product.ModifiedAt,
                ModifiedBy = product.ModifiedBy,
                Tags = product.ProductTags.Select(pt => pt.TagId),
                Categories = product.ProductCategories.Select(pc => pc.CategoryId),
                Images = product.Images.Select(i => i.Id),
            };

            return productDto;
        }
    }
}