using ByteCart.Admin.Application.Products.DTOs;
using MediatR;

namespace ByteCart.Admin.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
    }
}