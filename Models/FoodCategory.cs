using System.ComponentModel.DataAnnotations;

namespace ITPEFoodReg.Models
{
    public class FoodCategory
    {
        public int FoodCategoryId { get; set; } // Primary key

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Description must not exceed 200 characters.")]
        public string Description { get; set; } = string.Empty;

        // Navigation property for related FoodItems
        public ICollection<FoodItem>? FoodItems { get; set; }
    }
}