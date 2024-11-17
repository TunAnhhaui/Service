using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Dto;
using api.Models;
using api.Services;

namespace Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            var message = await _categoryService.CreateCategoryAsync(categoryDto);
            if (message == "Tên không được để trống" || message == "Danh mục không được để trống")
            {
                return BadRequest(message);
            }
            return Ok(message);
        }

        [HttpGet("getByPage")]
        public async Task<IActionResult> GetByPage(int page = 1, int limit = 10)
        {
            var categories = await _categoryService.GetCategoriesByPageAsync(page, limit);
            return Ok(categories);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("getByCategoryType/{id}")]
        public async Task<IActionResult> GetByCategoryType(int id)
        {
            var categories = await _categoryService.GetCategoriesByTypeAsync(id);
            return Ok(categories);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var message = await _categoryService.DeleteCategoryAsync(id);
            if (message == "Không tìm thấy dữ liệu")
            {
                return Conflict(message);
            }
            return Ok(message);
        }
    }

}
