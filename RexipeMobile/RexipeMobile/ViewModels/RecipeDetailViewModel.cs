using System;

using RexipeMobile.Models;
using RexipeModels;

namespace RexipeMobile.ViewModels
{
    public class RecipeDetailViewModel : BaseViewModel
    {
        public Recipe Recipe { get; set; }
        public RecipeDetailViewModel(Recipe recipe = null)
        {
            Title = recipe?.Title;
            Recipe = recipe;
        }
    }
}
