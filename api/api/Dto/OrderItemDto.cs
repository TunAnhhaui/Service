namespace api.Dto
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
