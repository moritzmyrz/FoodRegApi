using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITPEFoodReg.Models
{
    public class FoodItem
    {
        public int FoodItemId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(200, ErrorMessage = "Description must not exceed 200 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid category.")]
        public int FoodCategoryId { get; set; }

        [ForeignKey("FoodCategoryId")]
        public FoodCategory? FoodCategory { get; set; } // Navigation property

        [Range(0, 10000, ErrorMessage = "Calories must be between 0 and 10,000.")]
        public double Calories { get; set; }

        [Range(0, 1000, ErrorMessage = "Protein must be between 0 and 1,000 grams.")]
        public double Protein { get; set; }

        [Range(0, 1000, ErrorMessage = "Fat must be between 0 and 1,000 grams.")]
        public double Fat { get; set; }

        [Range(0, 1000, ErrorMessage = "Carbohydrates must be between 0 and 1,000 grams.")]
        public double Carbohydrates { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}