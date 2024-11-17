namespace api.Services
{
    using api.Dto;
    using api.Models;

    public interface CategoryTypeService
    {
        Task<string> CreateCategoryTypeAsync(CategoryTypeDto categoryTypeDto);
        Task<List<CategoryType>> GetAllCategoryTypesAsync();
        Task<CategoryType?> GetCategoryTypeByIdAsync(int id);
    }

}
