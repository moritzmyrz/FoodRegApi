using ITPEFoodReg.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ITPEFoodReg.Repositories
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FoodItem>> GetAllAsync()
        {
            // Include both FoodCategory and Image in the query
            return await _context.FoodItems
                .Include(f => f.FoodCategory) // Ensure category is included
                .ToListAsync();
        }

        public async Task<IEnumerable<FoodItem>> GetAllAsync(Expression<Func<FoodItem, bool>> predicate)
        {
            // Include both FoodCategory and Image in the filtered query
            return await _context.FoodItems
                .Include(f => f.FoodCategory) // Include category for filtered items
                .Where(predicate) // Apply the filter
                .ToListAsync();
        }

        public async Task<FoodItem?> GetByIdAsync(int id)
        {
            // Include both FoodCategory and Image when retrieving by ID
            return await _context.FoodItems
                .Include(f => f.FoodCategory) // Include related FoodCategory
                .FirstOrDefaultAsync(f => f.FoodItemId == id);
        }

        public async Task AddAsync(FoodItem item)
        {
            await _context.FoodItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FoodItem item)
        {
            var existingItem = await _context.FoodItems
                .AsNoTracking() // Prevent tracking conflicts
                .FirstOrDefaultAsync(f => f.FoodItemId == item.FoodItemId);

            if (existingItem != null)
            {
                // Update the existing item
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                _context.FoodItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.FoodItems.AnyAsync(i => i.FoodItemId == id);
        }
    }
}