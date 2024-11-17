using api.Dto;
using System.Security.Claims;

namespace api.Services
{
    public interface IUserPromotionService
    {
        Task AddPromotionForUserAsync(ClaimsPrincipal user, UserPromotionDto userPromotionDto);
    }
}
