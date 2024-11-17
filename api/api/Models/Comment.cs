namespace api.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string? CommentText { get; set; }
        public string? ImageUrl { get; set; }
        public int? Rate { get; set; }
        public DateTime CreatedDate { get; set; }

        public User User { get; set; }

    }
}
