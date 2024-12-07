using api.Data;
using api.Models;
using api.Repository.Irepository;

namespace api.Repository
{
    public class UserPromotionRepository : IUserPromotionRepository
    {
        private readonly AppDbContext _context;

        public UserPromotionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddUserPromotionAsync(UserPromotion userPromotion)
        {
            _context.userPromotion.Add(userPromotion);
            await _context.SaveChangesAsync();
        }
    }
}
