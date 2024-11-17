using api.Dto;

namespace api.Services
{
    public interface IPromotionService
    {
        Task<IEnumerable<object>> GetAllPromotionsAsync();
        Task CreatePromotionAsync(PromotionDto promotionDto);
        Task UpdatePromotionStatusAsync(int id, bool status);
    }
}
