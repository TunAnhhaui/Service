using api.Dto;
using api.Models;
using api.Repository.Irepository;
using Microsoft.EntityFrameworkCore;
using api.Services;
namespace api.Services.Impl
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _repository;

        public PromotionService(IPromotionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<object>> GetAllPromotionsAsync()
        {
            var promotions = await _repository.GetAllAsync();
            var result = promotions.Select(promotion => new
            {
                Name = promotion.Name,
                DiscountRate = promotion.DiscountRate,
                Code = promotion.Code,
                Status = promotion.Status,
                StartDate = promotion.StartDate,
                EndDate = promotion.EndDate,
                IsActive = promotion.IsActive,
                UserPromotions = promotion.UserPromotions.Select(up => new
                {
                    UserId = up.UserId,
                    UserEmail = up.PromotionId
                }).ToList()

            }).ToList();
            return promotions;
        }

        public async Task CreatePromotionAsync(PromotionDto promotionDto)
        {
            var newPromotion = new Promotion
            {
                Name = promotionDto.Name,
                DiscountRate = promotionDto.DiscountRate,
                Code = promotionDto.Code,
                StartDate = promotionDto.StartDate,
                EndDate = promotionDto.EndDate,
            };

            await _repository.AddAsync(newPromotion);
        }

        public async Task UpdatePromotionStatusAsync(int id, bool status)
        {
            var promotion = await _repository.GetByIdAsync(id);
            if (promotion != null)
            {
                promotion.Status = status;
                await _repository.UpdateAsync(promotion);
            }
        }
    }
}
