using Microsoft.EntityFrameworkCore;
using RexipeMobile.MobileAppService.Data;
using RexipeModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RexipeMobile.Models
{
    public class RecipeRepository
    {
        public RexipeDbContext RexipeDb { get; }

        public RecipeRepository(RexipeDbContext rexipeDb)
        {
            RexipeDb = rexipeDb;
        }

        /// <summary>
        /// Gets all the recipes in the database (no details).
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Recipe>> GetAll()
        {
            return await RexipeDb.Recipes
                .ToListAsync();
        }

        /// <summary>
        /// Gets a specific recipe from the database (no details).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Recipe> GetRecipe(int id)
        {
            var recipes = await RexipeDb.Recipes
                .Where(r => r.Id == id)
                .ToListAsync();

            return recipes.FirstOrDefault();
        }

        /// <summary>
        /// Gets the list of ingredients for a specific recipe. Includes the ingredient descriptions and quantities.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IngredientQuantity>> GetRecipeIngredients(int recipeId)
        {
            var recipes = await RexipeDb.Recipes
                .Include(r => r.Ingredients).ThenInclude(i => i.Quantity)
                .Include(r => r.Ingredients).ThenInclude(i => i.Ingredient)
                .Where(r => r.Id == recipeId)
                .ToListAsync();

            var recipe = recipes.FirstOrDefault();
            if (recipe == null)
            {
                return null;
            }

            return recipe.Ingredients
                .OrderBy(i => i.Order)
                .AsEnumerable();
        }

        /// <summary>
        /// Gets the directions for a specific recipe.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RecipeDirection>> GetRecipeDirections(int recipeId)
        {
            var recipes = await RexipeDb.Recipes
                .Include(r => r.Directions)
                .Where(r => r.Id == recipeId)
                .ToListAsync();

            var recipe = recipes.FirstOrDefault();
            if (recipe == null)
            {
                return null;
            }

            return recipe.Directions
                .OrderBy(d => d.Order)
                .AsEnumerable();
        }
    }
}
