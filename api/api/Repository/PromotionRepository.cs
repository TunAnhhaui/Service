using api.Data;
using api.Models;
using api.Repository.Irepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly AppDbContext _context;
        public PromotionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Promotion>> GetAllAsync()
        {
            return await _context.promotion
                .Include(p => p.UserPromotions)
                .OrderByDescending(p => p.StartDate)
                .ToListAsync();
        }

        public async Task<Promotion> GetByIdAsync(int id)
        {
            return await _context.promotion.FindAsync(id);
        }

        public async Task AddAsync(Promotion promotion)
        {
            await _context.promotion.AddAsync(promotion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Promotion promotion)
        {
            _context.promotion.Update(promotion);
            await _context.SaveChangesAsync();
        }
    }
}
