using api.Dto;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PromotionController : Controller
    {
        private readonly IPromotionService _service;

        public PromotionController(IPromotionService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PromotionDto promotionDto)
        {
            await _service.CreatePromotionAsync(promotionDto);
            return Ok("Thêm mới thành công");
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var promotions = await _service.GetAllPromotionsAsync();
            return Ok(promotions);
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] bool status)
        {
            await _service.UpdatePromotionStatusAsync(id, status);
            return Ok();
        }
    }
}
