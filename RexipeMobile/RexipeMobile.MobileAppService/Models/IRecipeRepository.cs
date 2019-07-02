using RexipeModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RexipeMobile.Models
{
    public interface IRecipeRepository
    {
        Task Add(Recipe recipe);
        Task Update(Recipe recipe);
        Task<Recipe> Remove(int id);
        Task<Recipe> Get(int id);
        Task<IEnumerable<Recipe>> GetAll();
    }
}
