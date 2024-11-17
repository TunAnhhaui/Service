namespace api.Dto
{
    public class PromotionDto
    {
        public string Name { get; set; }
        public decimal DiscountRate { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
