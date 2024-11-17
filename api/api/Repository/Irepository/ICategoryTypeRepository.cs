using api.Models;

namespace api.Repository.Irepository
{
    public interface ICategoryTypeRepository
    {
        Task CreateAsync(CategoryType categoryType);
        Task<List<CategoryType>> GetAllAsync();
        Task<CategoryType?> GetByIdAsync(int id);
    }
}
