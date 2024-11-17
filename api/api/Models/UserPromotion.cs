namespace api.Models
{
    public class UserPromotion
    {
        public int UserPromotionId { get; set; } 
        public int UserId { get; set; } 
        public int PromotionId { get; set; } 
        public DateTime UsedDate { get; set; }

        public User? User { get; set; }
    }
}
