namespace ByteCart.Admin.Application.Products.Commands
{
    public record UpdateProductCommand 
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime LaunchDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid SupplierId { get; set; }
        public IEnumerable<string> Tags { get; set; } = new List<string>();
        public IEnumerable<string> Categories { get; set; } = new List<string>();
        public IEnumerable<string> Images { get; set; } = new List<string>();
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}