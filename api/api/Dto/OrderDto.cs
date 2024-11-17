namespace api.Dto
{
    public class OrderDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public string? Description { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Payment { get; set; }
        public string? PaymentStatus { get; set; }
        public string? ShippingStatus { get; set; }
        public List<OrderItemDto>? OrderItems { get; set; }
    }
}
