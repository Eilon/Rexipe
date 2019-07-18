using RexipeMobile.Services;
using RexipeModels;
using System;
using System.Collections.ObjectModel;
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

        public ObservableCollection<IngredientQuantity> Ingredients { get; } = new ObservableCollection<IngredientQuantity>();

        public ObservableCollection<RecipeDirection> Directions { get; } = new ObservableCollection<RecipeDirection>();
        public bool Loaded { get; private set; }

        private async Task ExecuteLoadRecipeDetailsCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                Ingredients.Clear();
                var ingredients = (await DataStore.GetRecipeIngredients(Recipe.Id)).ToList();
                foreach (var ingredient in ingredients)
                {
                    Ingredients.Add(ingredient);
                }
                OnPropertyChanged("Ingredients");

                Directions.Clear();
                var directions = (await DataStore.GetRecipeDirections(Recipe.Id)).ToList();
                foreach (var direction in directions)
                {
                    Directions.Add(direction);
                }
                OnPropertyChanged("Directions");

                Loaded = true;
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
