namespace SalesService.Models.DTO
{
    public class ProductCreateRequestDTO
    {
        public string Description { get; set; } = string.Empty;
        public DateTime Registration { get; set; } = DateTime.UtcNow;
        public int CustomerId { get; set; }
    }
}