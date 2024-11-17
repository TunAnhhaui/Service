using api.Data;
using api.Dto;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductImageController : Controller
    {
        private readonly AppDbContext _context;
        public ProductImageController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProductImageDto productImageDto)
        {
            var newProductImage = new ProductImage
            {
                ImageUrl = productImageDto.ImageUrl,
                ProductId = productImageDto.ProductId
            };
            _context.productImages.Add(newProductImage);
            await _context.SaveChangesAsync();
            return Ok("Thêm thành công");
        }
        [HttpGet("getByProduct/{id}")]
        public async Task<IActionResult> GetByProduct(int id)
        {
            var images=await _context.productImages.Where(x=>x.ProductId==id).ToListAsync();
            return Ok(images);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var image = await _context.productImages.FindAsync(id);
            _context.productImages.Remove(image);
            await _context.SaveChangesAsync();
            return Ok("Xóa thành công");
        }
    }
}
