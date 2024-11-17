using api.Data;
using api.Dto;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductColorController : Controller
    {
        private readonly AppDbContext _context;
        public ProductColorController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProductColorDto productColorDto)
        {
            var productColor=await _context.productColors
                .FirstOrDefaultAsync(c=>c.ProductId==productColorDto.ProductId
                && c.ColorId==productColorDto.ColorId);
            if (productColor != null)
            {
                return BadRequest();
            }
            var newProductColor = new ProductColor
            {
                ProductId = productColorDto.ProductId,
                ColorId = productColorDto.ColorId
            };
            _context.productColors.Add(newProductColor);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
