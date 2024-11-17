using api.Data;
using api.Dto;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ColorController : Controller
    {
        private readonly AppDbContext _context;
        public ColorController(AppDbContext context) {
            _context = context;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ColorDto colorDto)
        {
            if (string.IsNullOrEmpty(colorDto.Name))
            {
                return BadRequest("Tên không được để trống");
            }
            if (string.IsNullOrEmpty(colorDto.Code))
            {
                return BadRequest("Mã màu không được để trống");
            }
            var newColor = new Color
            {
                Name = colorDto.Name,
                Code = colorDto.Code
            };
            _context.colors.Add(newColor);
            await _context.SaveChangesAsync();
            return Ok("Thêm thành công");
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var colors = await _context.colors.ToListAsync();
            return Ok(colors);
        }
    }
}
