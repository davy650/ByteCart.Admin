using MediatR;

namespace ByteCart.Admin.Application.Products.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; }
    }
}