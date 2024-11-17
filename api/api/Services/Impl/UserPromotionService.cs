using api.Dto;
using api.Models;
using System.Security.Claims;
using api.Repository.Irepository;
namespace api.Services.Impl
{
    public class UserPromotionService : IUserPromotionService
    {
        private readonly IUserPromotionRepository _repository;

        public UserPromotionService(IUserPromotionRepository repository)
        {
            _repository = repository;
        }

        public async Task AddPromotionForUserAsync(ClaimsPrincipal user, UserPromotionDto userPromotionDto)
        {
            var userIdString = user.FindFirst("UserId")?.Value;
            if (string.IsNullOrEmpty(userIdString))
            {
                throw new UnauthorizedAccessException("Bạn cần đăng nhập để mua hàng");
            }

            int userId = int.Parse(userIdString);

            var userPromotion = new UserPromotion
            {
                UserId = userId,
                PromotionId = userPromotionDto.PromotionId,
                UsedDate = DateTime.Now,
            };

            await _repository.AddUserPromotionAsync(userPromotion);
        }
    }
}
