using System.Threading;
using System.Threading.Tasks;
using ByteCart.Admin.Application.Commands.Products;
using ByteCart.Admin.Application.Interfaces;
using ByteCart.Admin.Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ByteCart.Admin.Application.Handlers.Products
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            if (product == null)
            {
                return false;
            }

            product.Name = request.Name;
            product.SKU = request.SKU;
            product.Description = request.Description;
            product.Price = request.Price;
            product.CostPrice = request.CostPrice;
            product.StockQuantity = request.StockQuantity;
            product.Status = request.Status;
            product.LaunchDate = request.LaunchDate;
            product.EndDate = request.EndDate;
            product.SupplierId = request.SupplierId;
            product.ModifiedAt = DateTime.UtcNow;
            product.ModifiedBy = request.ModifiedBy;

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

            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}