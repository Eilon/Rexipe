using System.Collections.Generic;
using System.Threading.Tasks;
using RexipeModels;

namespace RexipeMobile.Services
{
    public interface IRecipeStore
    {
        Task<IEnumerable<Recipe>> GetAllRecipesAsync(bool forceRefresh = false);
        Task<Recipe> GetRecipeAsync(int recipeId);
        Task<IEnumerable<IngredientQuantity>> GetRecipeIngredients(int recipeId);
        Task<IEnumerable<RecipeDirection>> GetRecipeDirections(int recipeId);
    }
}
