using ByteCart.Admin.Application.Commands.Products;
using ByteCart.Admin.Application.Interfaces;
using ByteCart.Admin.Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ByteCart.Admin.Application.Handlers.Products
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Include(p => p.ProductTags)
                .Include(p => p.ProductCategories)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);

            if (product == null)
            {
                return false;
            }

            // Remove related entities
            foreach (var productTag in product.ProductTags.ToList())
            {
                _context.ProductTags.Remove(productTag);
            }
            foreach (var productCategory in product.ProductCategories.ToList())
            {
                _context.ProductCategories.Remove(productCategory);
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}