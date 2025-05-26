using ByteCart.Admin.Application.Commands.Tags;
using ByteCart.Admin.Application.DTOs;
using ByteCart.Admin.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ByteCart.Admin.Application.Queries.Tags
{
    public class GetTagListQueryHander : IRequestHandler<GetTagListQueryCommand, List<TagDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetTagListQueryHander(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TagDto>> Handle(GetTagListQueryCommand request, CancellationToken cancellationToken)
        {
            var tags = await _context.Tags
                .OrderBy(t => t.Name)
                .ToListAsync(cancellationToken);
                
            return tags.Select(t => new TagDto
            {
                Id = t.Id,
                Name = t.Name
            }).ToList();
        }
    }
}