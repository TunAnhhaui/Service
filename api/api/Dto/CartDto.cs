namespace api.Dto
{
    public class CartDto
    {
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
