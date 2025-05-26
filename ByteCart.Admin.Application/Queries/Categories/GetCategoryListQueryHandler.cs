using ByteCart.Admin.Application.Commands.Categories;
using ByteCart.Admin.Application.DTOs;
using ByteCart.Admin.Application.Interfaces;
using ByteCart.Admin.Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ByteCart.Admin.Application.Queries.Categories
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQueryCommand, List<CategoryDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetCategoryListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryListQueryCommand request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories
                .Include(p => p.ProductCategories)
                .OrderBy(c => c.Name)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ParentCategoryId = c.ParentCategoryId,
                    CreatedAt = c.CreatedAt,
                    CreatedBy = c.CreatedBy,
                    ProductCount = c.ProductCategories.Count,
                })
                .ToListAsync(cancellationToken);

            var levelOneCategories = categories
                .Where(c => c.ParentCategoryId == null)
                .ToList();

            foreach (var category in levelOneCategories)
            {
                BuildNestedCategoryTree(category, categories);
            }

            return levelOneCategories;
        }

        private void BuildNestedCategoryTree(CategoryDto category, List<CategoryDto> allCategories)
        {
            category.SubCategories = allCategories
                .Where(c => c.ParentCategoryId == category.Id)
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var subCategory in category.SubCategories)
            {
                BuildNestedCategoryTree(subCategory, allCategories);
            }
        }
    }
}