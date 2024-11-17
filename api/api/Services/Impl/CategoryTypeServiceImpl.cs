namespace api.Services.Impl
{
    using api.Dto;
    using api.Models;
    using api.Repository.Irepository;

    public class CategoryTypeServiceImpl : CategoryTypeService
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;

        public CategoryTypeServiceImpl(ICategoryTypeRepository categoryTypeRepository)
        {
            _categoryTypeRepository = categoryTypeRepository;
        }

        public async Task<string> CreateCategoryTypeAsync(CategoryTypeDto categoryTypeDto)
        {
            if (string.IsNullOrEmpty(categoryTypeDto.Name))
            {
                return "Tên không được để trống";
            }

            var newCategoryType = new CategoryType
            {
                Name = categoryTypeDto.Name,
                Image = categoryTypeDto.Image
            };

            await _categoryTypeRepository.CreateAsync(newCategoryType);
            return "Thêm mới thành công";
        }

        public async Task<List<CategoryType>> GetAllCategoryTypesAsync()
        {
            return await _categoryTypeRepository.GetAllAsync();
        }

        public async Task<CategoryType?> GetCategoryTypeByIdAsync(int id)
        {
            return await _categoryTypeRepository.GetByIdAsync(id);
        }
    }

}
