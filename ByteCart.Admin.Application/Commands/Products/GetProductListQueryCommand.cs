using ByteCart.Admin.Application.Common;
using ByteCart.Admin.Application.DTOs;
using ByteCart.Admin.Domain.Enum;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ByteCart.Admin.Application.Commands.Products
{
    public class GetProductListQueryCommand : IRequest<PaginatedList<ProductDto>>
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
}