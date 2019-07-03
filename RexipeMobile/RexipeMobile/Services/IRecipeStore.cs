using System.Collections.Generic;
using System.Threading.Tasks;
using RexipeModels;

namespace RexipeMobile.Services
{
    public interface IRecipeStore
    {
        //Task<bool> AddRecipeAsync(Recipe recipe);
        //Task<bool> DeleteRecipeAsync(int id);
        Task<Recipe> GetRecipeAsync(int id);
        Task<IEnumerable<Recipe>> GetAllRecipesAsync(bool forceRefresh = false);
        //Task<bool> UpdateRecipeAsync(Recipe recipe);
    }
}