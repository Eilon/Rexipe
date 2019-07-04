using System;
using System.ComponentModel;
using Xamarin.Forms;
using RexipeMobile.ViewModels;
using RexipeModels;

namespace RexipeMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class RecipesPage : ContentPage
    {
        private readonly RecipesViewModel _viewModel;

        public RecipesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new RecipesViewModel();
        }

        async void OnRecipeSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Recipe recipe))
            {
                return;
            }

            await Navigation.PushAsync(new RecipeDetailPage(new RecipeDetailViewModel(recipe)));

            // Manually deselect item.
            RecipesListView.SelectedItem = null;
        }

        async void AddRecipe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewRecipePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Recipes.Count == 0)
            {
                _viewModel.LoadRecipesCommand.Execute(null);
            }
        }
    }
}