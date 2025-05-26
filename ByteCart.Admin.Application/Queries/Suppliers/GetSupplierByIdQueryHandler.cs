using ByteCart.Admin.Application.Commands.Suppliers;
using ByteCart.Admin.Application.DTOs;
using ByteCart.Admin.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ByteCart.Admin.Application.Queries.Suppliers
{
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQueryCommand, SupplierDto>
    {
        private readonly IApplicationDbContext _context;

        public GetSupplierByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SupplierDto> Handle(GetSupplierByIdQueryCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _context.Suppliers
                .Where(s => s.Id == request.Id)
                .Select(s => new SupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    ContactEmail = s.ContactEmail,
                    ContactNumber = s.ContactNumber,
                    Website = s.Website,
                    CreatedBy = s.CreatedBy,
                    ProductCount = _context.Products.Count(p => p.SupplierId == s.Id),
                    CreatedAt = s.CreatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);
                
            if (supplier == null)
            {
                throw new Exception($"Supplier with ID {request.Id} not found.");
            }

            return supplier;
        }
    }
}