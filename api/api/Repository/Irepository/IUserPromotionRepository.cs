using api.Models;

namespace api.Repository.Irepository
{
    public interface IUserPromotionRepository
    {
        Task AddUserPromotionAsync(UserPromotion userPromotion);
    }
}
