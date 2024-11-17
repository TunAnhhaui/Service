namespace api.Dto
{
    public class ProductSizeDto
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public decimal Price { get; set; }
        public decimal? Discounted { get; set; }
        public decimal? DiscountedPrice { get; set; }
    }
}
