namespace api.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public decimal? Discounted { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int CategoryId { get; set; }

        public int Sell { get; set; }
        public DateTime CreatedDate { get; set; }

        public Category Category { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }

        public ICollection<ProductColor> ProductColors { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
