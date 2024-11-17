using api.Dto;
using api.Models;
using api.Repository.Irepository;

namespace api.Services.Impl
{
    public class CategoryServiceImpl : CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServiceImpl(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<string> CreateCategoryAsync(CategoryDto categoryDto)
        {
            if (string.IsNullOrEmpty(categoryDto.Name))
            {
                return "Tên không được để trống";
            }
            if (categoryDto.CategoryTypeId <= 0)
            {
                return "Danh mục không được để trống";
            }

            var newCategory = new Category
            {
                Name = categoryDto.Name,
                Image = categoryDto.Image,
                CategoryTypeId = categoryDto.CategoryTypeId
            };

            await _categoryRepository.AddAsync(newCategory);
            return "Thêm mới thành công";
        }

        public async Task<List<Category>> GetCategoriesByPageAsync(int page, int limit)
        {
            return await _categoryRepository.GetByPageAsync(page, limit);
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<List<Category>> GetCategoriesByTypeAsync(int categoryTypeId)
        {
            return await _categoryRepository.GetByTypeAsync(categoryTypeId);
        }

        public async Task<string> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return "Không tìm thấy dữ liệu";
            }

            await _categoryRepository.DeleteAsync(category);
            return "Xóa thành công";
        }
    }
}
