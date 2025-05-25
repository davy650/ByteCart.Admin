using ByteCart.Admin.Application.Products.DTOs;
using ByteCart.Admin.Application.Products.Queries.Common;
using ByteCart.Admin.Domain.Enum;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ByteCart.Admin.Application.Products.Queries
{
    public class GetProductListQuery : IRequest<PaginatedList<ProductDto>>
    {
        public string? SearchTerm { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; } 
        public List<Guid>? CategoryIds { get; set; }
        public List<Guid>? TagIds { get; set; }
        public Guid? SupplierId { get; set; }
        public ProductStatus? Status { get; set; }

    }

    // // Handler
    // public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
    // {
    //     // Inject your data source, e.g., DbContext or repository
    //     public GetProductListQueryHandler(/* Inject dependencies here */)
    //     {
    //     }

    //     public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    //     {
    //         // Replace with actual data fetching logic
    //         var products = new List<ProductDto>
    //         {
    //             new ProductDto { Id = 1, Name = "Product 1" },
    //             new ProductDto { Id = 2, Name = "Product 2" }
    //         };

    //         return await Task.FromResult(products);
    //     }
    // }
}