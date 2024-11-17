using api.Models;

namespace api.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public decimal TotalAmount { get; set; }

        public Product Product { get; set; }
    }
}
