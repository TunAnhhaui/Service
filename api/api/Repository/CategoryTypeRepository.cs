namespace api.Repository
{
    using api.Data;
    using api.Models;
    using api.Repository.Irepository;
    using Microsoft.EntityFrameworkCore;

    public class CategoryTypeRepository : ICategoryTypeRepository
    {
        private readonly AppDbContext _context;

        public CategoryTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CategoryType categoryType)
        {
            await _context.categoryTypes.AddAsync(categoryType);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryType>> GetAllAsync()
        {
            return await _context.categoryTypes
                .Include(ct => ct.Categories) // Include liên kết đến Categories
                .ToListAsync();
        }

        public async Task<CategoryType?> GetByIdAsync(int id)
        {
            return await _context.categoryTypes.FindAsync(id);
        }
    }

}
