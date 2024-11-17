using api.Models;

namespace api.Repository.Irepository
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<List<Category>> GetByPageAsync(int page, int limit);
        Task<List<Category>> GetAllAsync();
        Task<List<Category>> GetByTypeAsync(int categoryTypeId);
        Task<Category?> GetByIdAsync(int id);
        Task DeleteAsync(Category category);
    }

}
