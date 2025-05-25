using MediatR;

namespace ByteCart.Admin.Application.Products.Commands
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int CategoryId { get; }
    }
}