namespace api.Services
{
    public interface INotificationService
    {
        Task<String> SendNotificationAsync(string message);
    }
}
