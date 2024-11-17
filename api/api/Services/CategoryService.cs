using api.Dto;
using api.Models;

namespace api.Services
{
    public interface CategoryService
    {
        Task<string> CreateCategoryAsync(CategoryDto categoryDto);
        Task<List<Category>> GetCategoriesByPageAsync(int page, int limit);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<Category>> GetCategoriesByTypeAsync(int categoryTypeId);
        Task<string> DeleteCategoryAsync(int id);

    }
}
