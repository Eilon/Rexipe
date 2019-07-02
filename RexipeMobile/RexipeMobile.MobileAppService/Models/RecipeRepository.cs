using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using RexipeModels;
using RexipeMobile.MobileAppService.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RexipeMobile.Models
{
    public class RecipeRepository : IRecipeRepository
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

        public Task Add(Recipe recipe)
        {
            // TODO: Check that this is correct
            RexipeDb.Recipes.Add(recipe);
            return RexipeDb.SaveChangesAsync();
        }

        public async Task<Recipe> Get(int id)
        {
            var recipes = await RexipeDb.Recipes
                .Include(r => r.Ingredients).ThenInclude(i => i.Quantity)
                .Include(r => r.Ingredients).ThenInclude(i => i.Ingredient)
                .Include(r => r.Directions)
                .Where(r => r.Id == id)
                .ToListAsync();

            return recipes.FirstOrDefault();
        }

        public Task<Recipe> Remove(int id)
        {
            throw new NotImplementedException();
            //recipes.TryRemove(id, out var recipe);

            //return recipe;
        }

        public Task Update(Recipe recipe)
        {
            throw new NotImplementedException();
            //recipes[recipe.Id] = recipe;
        }
    }
}
