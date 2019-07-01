using System.Collections.Generic;
using System.Threading.Tasks;
using RexipeModels;

namespace RexipeMobile.Services
{
    public interface IRecipeStore
    {
        Task<bool> AddItemAsync(Recipe item);
        Task<bool> DeleteItemAsync(int id);
        Task<Recipe> GetItemAsync(int id);
        Task<IEnumerable<Recipe>> GetItemsAsync(bool forceRefresh = false);
        Task<bool> UpdateItemAsync(Recipe item);
    }
}