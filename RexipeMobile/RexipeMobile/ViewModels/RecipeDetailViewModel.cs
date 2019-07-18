using RexipeMobile.Services;
using RexipeModels;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

            Ingredients.CollectionChanged += Ingredients_CollectionChanged;
            Directions.CollectionChanged += Directions_CollectionChanged;
        }

        private void Ingredients_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaiseCollectionPropertyChanged(e, Ingredients, nameof(IsIngredientsListVisible));
        }

        private void Directions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaiseCollectionPropertyChanged(e, Directions, nameof(IsDirectionsListVisible));
        }

        private void RaiseCollectionPropertyChanged(NotifyCollectionChangedEventArgs e, ICollection collection, string changePropertyName)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset ||
                (e.Action == NotifyCollectionChangedAction.Add && collection.Count == 1) ||
                (e.Action == NotifyCollectionChangedAction.Remove && collection.Count == 0))
            {
                OnPropertyChanged(changePropertyName);
            }
        }

        /// <summary>
        /// Contains only the basic recipe details, as seen on the main recipes list page. Doesn't contain
        /// navigation properties such as ingredients, directions, etc.
        /// </summary>
        public Recipe Recipe { get; }

        public ObservableCollection<IngredientQuantity> Ingredients { get; } = new ObservableCollection<IngredientQuantity>();
        public bool IsIngredientsListVisible => Ingredients.Any();
        public bool IsDirectionsListVisible => Directions.Any();

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

                Directions.Clear();
                var directions = (await DataStore.GetRecipeDirections(Recipe.Id)).ToList();
                foreach (var direction in directions)
                {
                    Directions.Add(direction);
                }

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
