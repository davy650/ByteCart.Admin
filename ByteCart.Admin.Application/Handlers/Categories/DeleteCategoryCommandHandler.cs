using ByteCart.Admin.Application.Commands.Categories;
using ByteCart.Admin.Application.Interfaces;
using MediatR;

namespace ByteCart.Admin.Application.Handlers.Categories
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(request.CategoryId);
            if (category == null)
            {
                return false; 
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);

            return true; 
        }
    }
}