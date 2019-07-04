using RexipeMobile.Services;
using RexipeModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RexipeMobile.ViewModels
{
    public class RecipeDetailViewModel : BaseViewModel
    {
        private IRecipeStore DataStore { get; } = DependencyService.Get<IRecipeStore>();
        public Command LoadRecipeDetailsCommand { get; set; }

        public RecipeDetailViewModel(Recipe recipe = null)
        {
            Title = recipe?.Title;
            Recipe = recipe;
            LoadRecipeDetailsCommand = new Command(async () => await ExecuteLoadRecipeDetailsCommand());
        }

        /// <summary>
        /// Contains only the basic recipe details, as seen on the main recipes list page. Doesn't contain
        /// navigation properties such as ingredients, directions, etc.
        /// </summary>
        public Recipe Recipe { get; }

        public List<IngredientQuantity> Ingredients { get; set; }
        public List<RecipeDirection> Directions { get; set; }

        public bool HasIngredients => Ingredients?.Any() ?? false;
        public bool NotHasIngredients => !HasIngredients;

        private async Task ExecuteLoadRecipeDetailsCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                Ingredients = (await DataStore.GetRecipeIngredients(Recipe.Id)).ToList();
                Directions = (await DataStore.GetRecipeDirections(Recipe.Id)).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
