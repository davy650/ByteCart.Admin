namespace ByteCart.Admin.Domain.Entities.Products
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}