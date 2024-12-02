using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITPEFoodReg.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<FoodCategory>()
                .HasMany(fc => fc.FoodItems)
                .WithOne(fi => fi.FoodCategory)
                .HasForeignKey(fi => fi.FoodCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure timestamps
            modelBuilder.Entity<FoodItem>()
                .Property(fi => fi.CreatedAt)
                .IsRequired();

            modelBuilder.Entity<FoodItem>()
                .Property(fi => fi.UpdatedAt)
                .IsRequired();

            // Avoid duplicate configuration of relationships (already configured above)
            // Seed FoodCategories
            modelBuilder.Entity<FoodCategory>().HasData(
                new FoodCategory
                {
                    FoodCategoryId = 1,
                    Name = "Fruits",
                    Description = "All kinds of fruits."
                },
                new FoodCategory
                {
                    FoodCategoryId = 2,
                    Name = "Vegetables",
                    Description = "Fresh and healthy vegetables."
                },
                new FoodCategory
                {
                    FoodCategoryId = 3,
                    Name = "Dairy",
                    Description = "Milk and milk products."
                }
            );

            // Seed FoodItems
            modelBuilder.Entity<FoodItem>().HasData(
                new FoodItem
                {
                    FoodItemId = 1,
                    Name = "Apple",
                    Description = "A sweet red fruit.",
                    Calories = 52,
                    Protein = 0.3,
                    Fat = 0.2,
                    Carbohydrates = 14,
                    FoodCategoryId = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new FoodItem
                {
                    FoodItemId = 2,
                    Name = "Carrot",
                    Description = "A crunchy orange vegetable.",
                    Calories = 41,
                    Protein = 0.9,
                    Fat = 0.2,
                    Carbohydrates = 10,
                    FoodCategoryId = 2,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new FoodItem
                {
                    FoodItemId = 3,
                    Name = "Cheese",
                    Description = "A block of tasty cheddar cheese.",
                    Calories = 402,
                    Protein = 25,
                    Fat = 33,
                    Carbohydrates = 1.3,
                    FoodCategoryId = 3,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}