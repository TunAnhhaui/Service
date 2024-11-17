namespace api.Dto
{
    public class ProductDto
    {
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public decimal? Discounted { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public DateTime? CreatedDate { get; set; }


        public int CategoryId { get; set; }
    }
}
