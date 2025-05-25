using MediatR;

namespace ByteCart.Admin.Application.Products.Commands
{
    public record UpdateCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}