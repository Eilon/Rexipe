using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using RexipeMobile.Models;
using RexipeMobile.Views;
using RexipeMobile.ViewModels;
using RexipeModels;

namespace RexipeMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class RecipesPage : ContentPage
    {
        readonly RecipesViewModel viewModel;

        public RecipesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RecipesViewModel();
        }

        async void OnRecipeSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Recipe item))
                return;

            await Navigation.PushAsync(new RecipeDetailPage(new RecipeDetailViewModel(item)));

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

            if (viewModel.Recipes.Count == 0)
                viewModel.LoadRecipesCommand.Execute(null);
        }
    }
}