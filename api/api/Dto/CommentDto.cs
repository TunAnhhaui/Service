namespace api.Dto
{
    public class CommentDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string? CommentText { get; set; }
        public string? ImageUrl { get; set; }
        public int? Rate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
