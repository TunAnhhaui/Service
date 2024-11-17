namespace api.Models
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public string Name { get; set; }
        public decimal DiscountRate { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public ICollection<UserPromotion>? UserPromotions { get; set; }
        public bool IsActive
        {
            get
            {
                return StartDate <= DateTime.Now 
                    && (EndDate == null || EndDate?.Date >= DateTime.Now);
            }
        }
    }
}
