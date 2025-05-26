using ByteCart.Admin.Application.Commands.Categories;
using ByteCart.Admin.Application.DTOs;
using ByteCart.Admin.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ByteCart.Admin.Application.Queries.Categories
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryCommand, CategoryDto>
    {
        private readonly IApplicationDbContext _context;

        public GetCategoryByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQueryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .Include(p => p.ProductCategories)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            // TODO: Aggregate to error handling middleware or throw custom exception

            if (category == null)
            {
                return null;  
            }

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ParentCategoryId = category.ParentCategoryId,
                CreatedAt = category.CreatedAt,
                CreatedBy = category.CreatedBy,
                ProductCount = category.ProductCategories.Count,
            };
        }
    }
}