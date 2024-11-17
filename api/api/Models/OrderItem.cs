namespace api.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public decimal TotalAmount { get; set; }

        public Product Product { get; set; }
    }
}
