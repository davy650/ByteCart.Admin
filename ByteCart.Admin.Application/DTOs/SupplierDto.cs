namespace ByteCart.Admin.Application.DTOs
{
    public class SupplierDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }
        public string? Website { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public int ProductCount { get; set; }
    }
}