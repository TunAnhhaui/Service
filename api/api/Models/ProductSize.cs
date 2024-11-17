namespace api.Models
{
    public class ProductSize
    {
        public int ProductSizeId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public decimal Price { get; set; }
        public decimal? Discounted { get; set; }
        public decimal? DiscountedPrice { get; set; }

        public Size Size { get; set; }
    }
}
