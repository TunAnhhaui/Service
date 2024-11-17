using api.Data;
using api.Dto;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PromotionController : Controller
    {
        private readonly AppDbContext _context;
        public PromotionController(AppDbContext context)
        {
            _context=context;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PromotionDto promotionDto)
        {
            var newPromotion = new Promotion
            {
                Name = promotionDto.Name,
                DiscountRate = promotionDto.DiscountRate,
                Code = promotionDto.Code,
                StartDate = promotionDto.StartDate,
                EndDate=promotionDto.EndDate,
            };

            _context.promotion.Add(newPromotion);
            await _context.SaveChangesAsync();
            return Ok("Thêm mới thành công");
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var promotions = await _context.promotion
                .Include(p=>p.UserPromotions)
                .OrderByDescending(p => p.StartDate).ToListAsync();
            var result = promotions.Select(promotion => new 
            {
                Name=promotion.Name,
                DiscountRate=promotion.DiscountRate,
                Code = promotion.Code,
                Status = promotion.Status,
                StartDate=promotion.StartDate,
                EndDate=promotion.EndDate,
                IsActive=promotion.IsActive,
                UserPromotions = promotion.UserPromotions.Select(up => new 
                {
                    UserId = up.UserId,
                    UserEmail = up.PromotionId
                }).ToList()

            }).ToList();
            return Ok(promotions);
        }
        [HttpPatch("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] bool status)
        {
            var promotions = await _context.promotion.FindAsync(id);
            promotions.Status= status;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
