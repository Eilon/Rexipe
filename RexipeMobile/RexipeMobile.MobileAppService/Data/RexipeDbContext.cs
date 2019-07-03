using Microsoft.EntityFrameworkCore;
using RexipeModels;

namespace RexipeMobile.MobileAppService.Data
{
    public class RexipeDbContext : DbContext
    {
        public RexipeDbContext(DbContextOptions<RexipeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeAuthor> RecipeAuthors { get; set; }
        public DbSet<RecipeDirection> RecipeDirections { get; set; }
        public DbSet<IngredientQuantity> IngredientQuantities { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ItemQuantity> ItemQuantities { get; set; }
    }
}
