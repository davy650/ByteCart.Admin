using ByteCart.Admin.Application.DTOs;
using MediatR;

namespace ByteCart.Admin.Application.Commands.Tags
{

    public class GetTagListQueryCommand : IRequest<List<TagDto>>
    {
        public Guid? Id { get; set; }
    }
}