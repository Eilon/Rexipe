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

        public async Task<IEnumerable<Recipe>> GetAll()
        {
            return await RexipeDb.Recipes
                .Include(r => r.Ingredients).ThenInclude(i => i.Quantity)
                .Include(r => r.Ingredients).ThenInclude(i => i.Ingredient)
                .Include(r => r.Directions)
                .ToListAsync();
        }

        public async Task<Recipe> GetRecipeDetails(int id)
        {
            var recipes = await RexipeDb.Recipes
                .Include(r => r.Ingredients).ThenInclude(i => i.Quantity)
                .Include(r => r.Ingredients).ThenInclude(i => i.Ingredient)
                .Include(r => r.Directions)
                .Where(r => r.Id == id)
                .ToListAsync();

            return recipes.FirstOrDefault();
        }
    }
}
