using ByteCart.Admin.Application.DTOs;
using MediatR;

namespace ByteCart.Admin.Application.Commands.Products
{
    public class GetProductByIdQueryCommand : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
    }
}