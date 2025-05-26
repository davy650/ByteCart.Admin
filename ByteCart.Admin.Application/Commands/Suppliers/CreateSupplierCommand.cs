using MediatR;

namespace ByteCart.Admin.Application.Commands.Suppliers
{
    public class CreateSupplierCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }
        public string? Website { get; set; }
        public string? CreatedBy { get; set; }
    }
}