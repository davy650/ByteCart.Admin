using MediatR;

namespace ByteCart.Admin.Application.Commands.Products
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; }
    }
}