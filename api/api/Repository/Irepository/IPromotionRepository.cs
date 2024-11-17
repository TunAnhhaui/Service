using api.Models;

namespace api.Repository.Irepository
{
    public interface IPromotionRepository
    {
        Task<IEnumerable<Promotion>> GetAllAsync();
        Task<Promotion> GetByIdAsync(int id);
        Task AddAsync(Promotion promotion);
        Task UpdateAsync(Promotion promotion);
    }
}
