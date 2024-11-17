using api.Data;
using api.Dto;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    using global::api.Services;
    using Microsoft.AspNetCore.Mvc;

    namespace api.Controllers
    {
        [ApiController]
        [Route("[Controller]")]
        public class CategoryTypeController : Controller
        {
            private readonly CategoryTypeService _categoryTypeService;

            public CategoryTypeController(CategoryTypeService categoryTypeService)
            {
                _categoryTypeService = categoryTypeService;
            }

            [HttpPost("create")]
            public async Task<IActionResult> CreateCategoryType([FromBody] CategoryTypeDto categoryTypeDto)
            {
                var message = await _categoryTypeService.CreateCategoryTypeAsync(categoryTypeDto);
                if (message == "Tên không được để trống")
                {
                    return BadRequest(message);
                }
                return Ok(message);
            }

            [HttpGet("getAll")]
            public async Task<IActionResult> GetAll()
            {
                var categoryTypes = await _categoryTypeService.GetAllCategoryTypesAsync();
                return Ok(categoryTypes);
            }

            [HttpGet("getOne/{id}")]
            public async Task<IActionResult> GetOne(int id)
            {
                var categoryType = await _categoryTypeService.GetCategoryTypeByIdAsync(id);
                if (categoryType == null)
                {
                    return NotFound("Không tìm thấy loại danh mục.");
                }
                return Ok(categoryType);
            }
        }
    }

}
