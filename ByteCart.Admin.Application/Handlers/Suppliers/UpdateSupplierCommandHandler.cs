using ByteCart.Admin.Application.Commands.Suppliers;
using ByteCart.Admin.Application.Interfaces;
using MediatR;

namespace ByteCart.Admin.Application.Handlers.Suppliers
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSupplierCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _context.Suppliers.FindAsync(request.Id);
            if (supplier == null)
            {
                return false; 
            }

            supplier.Name = request.Name;
            supplier.ContactEmail = request.ContactEmail;
            supplier.ContactNumber = request.ContactNumber;
            supplier.Website = request.Website;
            supplier.ModifiedBy = request.ModifiedBy;

            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}