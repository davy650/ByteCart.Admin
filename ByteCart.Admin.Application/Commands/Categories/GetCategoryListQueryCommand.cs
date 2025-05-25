using ByteCart.Admin.Application.DTOs;
using MediatR;

namespace ByteCart.Admin.Application.Commands.Categories
{
    public class GetCategoryListQueryCommand : IRequest<List<CategoryDto>>
    {
        public Guid? Id { get; set; }
    }
}