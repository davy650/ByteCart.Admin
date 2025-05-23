using ByteCart.Admin.Domain.Entities.Products;

namespace ByteCart.Admin.Domain.Entities.Suppliers
{
    internal class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }
        public string? Website { get; set; }

        internal ICollection<Product> Products { get; set; } = new List<Product>();
    }
}