using ByteCart.Admin.Application.DTOs;
using MediatR;

namespace ByteCart.Admin.Application.Commands.Suppliers
{
    public class GetSupplierListQueryCommand : IRequest<List<SupplierDto>>
    {
        public Guid? Id { get; set; } 
    }
}