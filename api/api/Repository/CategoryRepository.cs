using api.Data;
using api.Models;
using api.Repository.Irepository;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetByPageAsync(int page, int limit)
        {
            return await _context.categories
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.categories.ToListAsync();
        }

        public async Task<List<Category>> GetByTypeAsync(int categoryTypeId)
        {
            return await _context.categories
                .Where(c => c.CategoryTypeId == categoryTypeId)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.categories.FindAsync(id);
        }

        public async Task DeleteAsync(Category category)
        {
            _context.categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
