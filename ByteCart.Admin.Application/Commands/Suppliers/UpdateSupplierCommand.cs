using MediatR;

namespace ByteCart.Admin.Application.Commands.Suppliers
{
    public class UpdateSupplierCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }
        public string? Website { get; set; }
        public string? ModifiedBy { get; set; }
    }
}