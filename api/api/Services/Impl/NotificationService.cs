using api.Data;
using api.Models;
using api.Services;
using api.Services.Impl;
using Microsoft.AspNetCore.SignalR;
using System.Net.Http;
using System.Text;
using System.Text.Json;

public class NotificationService : INotificationService
{
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly AppDbContext _context;

    public NotificationService(IHubContext<NotificationHub> hubContext, AppDbContext context)
    {
        _hubContext = hubContext;
        _context = context;
    }

    public async Task<String> SendNotificationAsync(string message)
    {
        // Gửi qua SignalR
        await _hubContext.Clients.All.SendAsync("ReceiveNotification", new
        {
            Message = message,

        });
        var notification = new Notification
        {
            Message = message,
        };

        _context.notifications.Add(notification);
        await _context.SaveChangesAsync();
        return "Notification sent successfully";
    }
}
