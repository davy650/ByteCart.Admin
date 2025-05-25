using ByteCart.Admin.Domain.Common;
using ByteCart.Admin.Domain.Entities.Products;

namespace ByteCart.Admin.Domain.Entities.Suppliers
{
    public class Supplier : Auditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }
        public string? Website { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}