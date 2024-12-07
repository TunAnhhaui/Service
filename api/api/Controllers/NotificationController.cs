using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class NotificationController : Controller
    {

        private readonly AppDbContext _context;
        public NotificationController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("getNotification")]
        public async Task<IActionResult> Get()
        {
            var notifications = await _context.notifications.Where(n => n.Status == false).ToListAsync();
            return Ok(notifications);
        }

        [HttpGet("MarkAllAsRead")]

        public async Task<IActionResult> MarkAllAsRead()
        {
            var notifications = await _context.notifications.Where(n => n.Status == false).ToListAsync();

            foreach (var notification in notifications)
            {
                notification.Status = true;
            }

            _context.notifications.UpdateRange(notifications);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Tất cả thông báo đã được đánh dấu là đã đọc." });
        }

    }
}
