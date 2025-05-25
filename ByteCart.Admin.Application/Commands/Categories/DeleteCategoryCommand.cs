using MediatR;

namespace ByteCart.Admin.Application.Commands.Categories
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int CategoryId { get; }
    }
}