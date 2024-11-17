using api.Data;
using api.Dto;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserPromotionController : Controller
    {
        private readonly AppDbContext _context;
        public UserPromotionController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserPromotionDto userPromotionDto)
        {
            var userIdString = User.FindFirst("UserId")?.Value;
            if (string.IsNullOrEmpty(userIdString))
            {
                return Unauthorized("Bạn cần đăng nhập để mua hàng");
            }
            int userId = int.Parse(userIdString);
            var UserPromotion = new UserPromotion
            {
                UserId = userId,
                PromotionId = userPromotionDto.PromotionId,
                UsedDate = DateTime.Now,
            };
            _context.userPromotion.Add(UserPromotion);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
