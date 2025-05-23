namespace ByteCart.Admin.Domain.Common
{
    internal abstract class Auditable
    {
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}