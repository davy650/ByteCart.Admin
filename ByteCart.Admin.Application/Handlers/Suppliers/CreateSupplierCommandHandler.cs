using ByteCart.Admin.Application.Commands.Suppliers;
using ByteCart.Admin.Application.Interfaces;
using ByteCart.Admin.Domain.Entities.Suppliers;
using MediatR;

namespace ByteCart.Admin.Application.Handlers.Suppliers
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateSupplierCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = new Supplier
            {
                Name = request.Name,
                ContactEmail = request.ContactEmail,
                ContactNumber = request.ContactNumber,
                Website = request.Website,
                CreatedBy = request.CreatedBy,
                CreatedAt = DateTime.UtcNow
            };

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync(cancellationToken);

            return supplier.Id;
        }
    }
}