using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using RexipeMobile.Models;
using RexipeMobile.Views;
using RexipeModels;
using RexipeMobile.Services;

namespace RexipeMobile.ViewModels
{
    public class RecipesViewModel : BaseViewModel
    {
        public MockRecipeStore DataStore => DependencyService.Get<MockRecipeStore>();

        public ObservableCollection<Recipe> Recipes { get; set; }
        public Command LoadRecipesCommand { get; set; }

        public RecipesViewModel()
        {
            Title = "Browse";
            Recipes = new ObservableCollection<Recipe>();
            LoadRecipesCommand = new Command(async () => await ExecuteLoadRecipesCommand());

            MessagingCenter.Subscribe<NewRecipePage, Recipe>(this, "AddRecipe", async (obj, item) =>
            {
                var newRecipe = item as Recipe;
                Recipes.Add(newRecipe);
                await DataStore.AddItemAsync(newRecipe);
            });
        }

        async Task ExecuteLoadRecipesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Recipes.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Recipes.Add(item);
                }
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