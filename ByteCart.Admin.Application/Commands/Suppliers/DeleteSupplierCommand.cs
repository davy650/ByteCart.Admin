using MediatR;

namespace ByteCart.Admin.Application.Commands.Suppliers
{
    public class DeleteSupplierCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}