using ITPEFoodReg.Models;
using System.Linq.Expressions;

namespace ITPEFoodReg.Repositories
{
    public interface IFoodItemRepository
    {
        // Retrieve all food items
        Task<IEnumerable<FoodItem>> GetAllAsync();

        // Retrieve food items with a filter
        Task<IEnumerable<FoodItem>> GetAllAsync(Expression<Func<FoodItem, bool>> predicate);

        // Retrieve a food item by ID
        Task<FoodItem?> GetByIdAsync(int id);

        // Add a new food item
        Task AddAsync(FoodItem item);

        // Update an existing food item
        Task UpdateAsync(FoodItem item);

        // Delete a food item by ID
        Task DeleteAsync(int id);

        // Check if a food item exists by ID
        Task<bool> ExistsAsync(int id);
    }
}