using ByteCart.Admin.Application.Commands.Suppliers;
using ByteCart.Admin.Application.Interfaces;
using MediatR;

namespace ByteCart.Admin.Application.Handlers.Suppliers
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSupplierCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _context.Suppliers.FindAsync(request.Id);
            if (supplier == null)
            {
                return false; 
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync(cancellationToken);
            return true; 
        }
    }
}