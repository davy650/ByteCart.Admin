using ByteCart.Admin.Application.Interfaces;
using ByteCart.Admin.Application.Products.DTOs;
using ByteCart.Admin.Application.Products.Queries;
using ByteCart.Admin.Application.Products.Queries.Common;
using ByteCart.Admin.Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, PaginatedList<ProductDto>>
{
    private readonly IApplicationDbContext _context;

    public GetProductListQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Product> query = _context.Products
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .Include(p => p.ProductTags)
            .ThenInclude(pt => pt.Tag)
            .Include(p => p.Images)
            .Include(p => p.Supplier);

        // Filter by search term
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            query = query.Where(
                p => p.Name.Contains(request.SearchTerm) ||
                p.Description.Contains(request.SearchTerm) ||
                p.SKU.Contains(request.SearchTerm));
        }

        if (request.CategoryIds != null && request.CategoryIds.Count > 0)
        {
            query = query.Where(p => p.ProductCategories.Any(pc => request.CategoryIds.Contains(pc.CategoryId)));
        }

        if (request.TagIds != null && request.TagIds.Count > 0)
        {
            query = query.Where(p => p.ProductTags.Any(pt => request.TagIds.Contains(pt.TagId)));
        }

        if (request.SupplierId.HasValue)
        {
            query = query.Where(p => p.SupplierId == request.SupplierId.Value);
        }

        if (request.Status.HasValue)
        {
            query = query.Where(p => p.Status == request.Status.Value);
        }

        // sort
        query = request.SortBy switch
        {
            "name" => query.OrderBy(p => p.Name),
            "price" => query.OrderBy(p => p.Price),
            "createdAt" => query.OrderByDescending(p => p.CreatedAt),
            _ => query.OrderByDescending(p => p.CreatedAt)
        };

        var totalCount = await query.CountAsync(cancellationToken);

        var products = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                Description = p.Description,
                Price = p.Price,
                CostPrice = p.CostPrice,
                StockQuantity = p.StockQuantity,
                Status = p.Status,
                LaunchDate = p.LaunchDate,
                EndDate = p.EndDate,
                SupplierId = p.SupplierId,
                CreatedAt = p.CreatedAt,
                CreatedBy = p.CreatedBy
            })
            .ToListAsync(cancellationToken);

        var paginatedList = new PaginatedList<ProductDto>(products, totalCount, request.PageNumber, request.PageSize);
        return paginatedList;
    }
}