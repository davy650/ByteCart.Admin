using ByteCart.Admin.Application.DTOs;
using MediatR;

namespace ByteCart.Admin.Application.Commands.Suppliers
{
    public class GetSupplierByIdQueryCommand : IRequest<SupplierDto>
    {
        public Guid Id { get; set; }
    }
}