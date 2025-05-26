using ByteCart.Admin.Application.DTOs;
using MediatR;

namespace ByteCart.Admin.Application.Commands.Categories
{
    public class GetCategoryByIdQueryCommand : IRequest<CategoryDto>
    {
        public Guid? Id { get; set; }
    }
}