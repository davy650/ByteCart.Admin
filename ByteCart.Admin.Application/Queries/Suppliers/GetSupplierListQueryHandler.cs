using ByteCart.Admin.Application.Commands.Suppliers;
using ByteCart.Admin.Application.DTOs;
using ByteCart.Admin.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ByteCart.Admin.Application.Queries.Suppliers
{


    public class GetSupplierListQueryHandler : IRequestHandler<GetSupplierListQueryCommand, List<SupplierDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetSupplierListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupplierDto>> Handle(GetSupplierListQueryCommand request, CancellationToken cancellationToken)
        {
            var supplers = await _context.Suppliers.OrderBy(s => s.Name).ToListAsync(cancellationToken);

            return supplers.Select(c => new SupplierDto
            {
                Id = c.Id,
                Name = c.Name,
                ContactEmail = c.ContactEmail,
                ContactNumber = c.ContactNumber,
                Website = c.Website,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                ModifiedAt = c.ModifiedAt,
                ModifiedBy = c.ModifiedBy
            }).ToList();

        }
    }
}