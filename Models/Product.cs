namespace SalesService.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime Registration { get; set; }
        public int CustomerId { get; set; }
    }
}