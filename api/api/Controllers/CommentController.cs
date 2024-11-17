using api.Data;
using api.Dto;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twilio.TwiML.Voice;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CommentController : Controller
    {
        private readonly AppDbContext _context;
        public CommentController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpPost("create/{id}")]
        public async Task<IActionResult> Create([FromBody] CommentDto commentDto,int id)
        {
            var userIdString = User.FindFirst("UserId")?.Value;
            if (string.IsNullOrEmpty(userIdString))
            {
                return Unauthorized(new{message= "Bạn cần đăng nhập để đánh giá"});
            }
            int userId = int.Parse(userIdString);

            var comment = new Comment
            {
                UserId = userId,
                ProductId = id,
                CommentText = commentDto.CommentText,
                ImageUrl = commentDto.ImageUrl,
                Rate = commentDto.Rate,
                CreatedDate = DateTime.Now,
            };

            _context.comments.Add(comment);
            await _context.SaveChangesAsync();

            return Ok(new {message="Đã tải bình luận"});
        }
        [HttpGet("getByProduct/{id}")]
        public async Task<IActionResult> GetByProduct(int id,int page=1,int limit=10)
        {
            var comments = await _context.comments
                .Where(c => c.ProductId == id)
                .ToListAsync();
            var count = comments.Count;
            double averageRate = 0;
            if (comments.Any(c => c.Rate.HasValue)) 
            {
                averageRate = await _context.comments
                    .Where(c => c.ProductId == id && c.Rate.HasValue)
                    .AverageAsync(c => (double)c.Rate);
            }
            var roundedAverageRate = Math.Round(averageRate, 1);
            var paginatedComments = await _context.comments
                               .Include(c=>c.User)
                              .Where(c => c.ProductId == id)
                              .OrderByDescending(c => c.CreatedDate) 
                              .Skip((page-1)*limit)
                              .Take(limit)
                              .ToListAsync();
            return Ok(new
            {
                Count = count,
                Comments = paginatedComments,
                AverageRate = roundedAverageRate,
            });
        }
        [HttpGet("GetCommentBest")]
        public async Task<IActionResult> GetCommentBest()
        {
            var comments = await _context.comments.Where(c => c.Rate >= 4).Include(c => c.User).ToListAsync();
                var productIds = comments.Select(c => c.ProductId).Distinct();
                var products = await _context.products
                    .Where(p => productIds.Contains(p.ProductId))
                    .ToListAsync();

                // Tạo đối tượng để trả về
                var result = products.Select(p => new
                {
                    Image = p.Image,
                    Comments = comments.Where(c => c.ProductId == p.ProductId)
                               .Select(c => new
                               {
                                   c.CommentId,
                                   c.CommentText,
                                   c.Rate,
                                   c.CreatedDate,
                                   User = new
                                   {
                                       c.User.Username,
                                       c.User.Email
                                   }
                               }).ToList()
                }).ToList();

                return Ok(result);
        }
    }
}
