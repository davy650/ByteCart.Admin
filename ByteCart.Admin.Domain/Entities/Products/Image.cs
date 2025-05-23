namespace ByteCart.Admin.Domain.Entities.Products
{
    internal class Image
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string? AltText { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;
    }
}