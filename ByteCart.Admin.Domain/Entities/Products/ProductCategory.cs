namespace ByteCart.Admin.Domain.Entities.Products
{
    public class ProductCategory
    {
        public Guid ProductId { get; set; }
        internal Product Product { get; set; } = default!;
        public Guid CategoryId { get; set; } 
        internal Category Category { get; set; } = default!;
        public bool IsActive { get; set; } = true;
    }
}