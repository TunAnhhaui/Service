namespace api.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; } = false;
    }
}
