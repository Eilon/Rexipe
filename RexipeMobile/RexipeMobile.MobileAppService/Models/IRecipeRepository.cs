using RexipeModels;
using System;
using System.Collections.Generic;

namespace RexipeMobile.Models
{
    public interface IRecipeRepository
    {
        void Add(Recipe recipe);
        void Update(Recipe recipe);
        Recipe Remove(int id);
        Recipe Get(int id);
        IEnumerable<Recipe> GetAll();
    }
}
