using System.Linq.Expressions;
using ITPEFoodReg.Models;

namespace ITPEFoodReg.Repositories
{
    public interface IFoodCategoryRepository
    {
        Task<IEnumerable<FoodCategory>> GetAllAsync();
        Task<IEnumerable<FoodCategory>> GetAllAsync(Expression<Func<FoodCategory, bool>> predicate);
        Task<FoodCategory?> GetByIdAsync(int id);
        Task AddAsync(FoodCategory category);
        Task UpdateAsync(FoodCategory category);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}