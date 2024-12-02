using System.Linq.Expressions;
using ITPEFoodReg.Models;
using Microsoft.EntityFrameworkCore;

namespace ITPEFoodReg.Repositories
{
    public class FoodCategoryRepository : IFoodCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FoodCategory>> GetAllAsync()
        {
            return await _context.FoodCategories.ToListAsync();
        }

        public async Task<IEnumerable<FoodCategory>> GetAllAsync(Expression<Func<FoodCategory, bool>> predicate)
        {
            return await _context.FoodCategories.Where(predicate).ToListAsync();
        }

        public async Task<FoodCategory?> GetByIdAsync(int id)
        {
            return await _context.FoodCategories
                .Include(c => c.FoodItems) // Include related FoodItems
                .FirstOrDefaultAsync(c => c.FoodCategoryId == id);
        }

        public async Task AddAsync(FoodCategory category)
        {
            _context.FoodCategories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FoodCategory category)
        {
            _context.FoodCategories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);
            if (category != null)
            {
                _context.FoodCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.FoodCategories.AnyAsync(c => c.FoodCategoryId == id);
        }
    }
}