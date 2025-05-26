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
            product.LaunchDate = DateTime.SpecifyKind(request.LaunchDate, DateTimeKind.Utc);
            product.EndDate = DateTime.SpecifyKind(request.EndDate, DateTimeKind.Utc);
            product.SupplierId = request.SupplierId;
            product.ModifiedAt = DateTime.UtcNow;
            product.ModifiedBy = request.ModifiedBy;

            // Update ProductCategories (Many-to-Many)
            var currentCategoryIds = product.ProductCategories.Select(pc => pc.CategoryId).ToList();
            var categoriesToAdd = request.Categories.Except(currentCategoryIds).ToList();
            var categoriesToRemove = currentCategoryIds.Except(request.Categories).ToList();

            foreach (var categoryId in categoriesToAdd)
            {
                product.ProductCategories.Add(new ProductCategory { ProductId = product.Id, CategoryId = categoryId });
            }
            foreach (var categoryId in categoriesToRemove)
            {
                var productCategoryToRemove = product.ProductCategories.FirstOrDefault(pc => pc.CategoryId == categoryId);
                if (productCategoryToRemove != null)
                {
                    product.ProductCategories.Remove(productCategoryToRemove);
                }
            }

            // Update ProductTags (Many-to-Many)
            var currentTagIds = product.ProductTags.Select(pt => pt.TagId).ToList();
            var tagsToAdd = request.Tags.Except(currentTagIds).ToList();
            var tagsToRemove = currentTagIds.Except(request.Tags).ToList();

            foreach (var tagId in tagsToAdd)
            {
                product.ProductTags.Add(new ProductTag { ProductId = product.Id, TagId = tagId });
            }
            foreach (var tagId in tagsToRemove)
            {
                var productTagToRemove = product.ProductTags.FirstOrDefault(pt => pt.TagId == tagId);
                if (productTagToRemove != null)
                {
                    product.ProductTags.Remove(productTagToRemove);
                }
            }

            // Handle new tags (similar to CreateProductCommand)
            foreach (var newTagName in request.NewTagNames)
            {
                // Check if tag already exists in DB
                var existingTag = await _context.Tags.FirstOrDefaultAsync(t => t.Name.ToLower() == newTagName.ToLower(), cancellationToken);
                if (existingTag == null)
                {
                    existingTag = new Tag { Id = Guid.NewGuid(), Name = newTagName };
                    _context.Tags.Add(existingTag);
                }

                // Add the association if it doesn't already exist for this product
                if (!product.ProductTags.Any(pt => pt.TagId == existingTag.Id))
                {
                    product.ProductTags.Add(new ProductTag { ProductId = product.Id, Tag = existingTag });
                }
            }

            
            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}