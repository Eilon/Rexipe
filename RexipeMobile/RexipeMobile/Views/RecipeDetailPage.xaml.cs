using System.ComponentModel;
using Xamarin.Forms;
using RexipeMobile.ViewModels;
using RexipeModels;

namespace RexipeMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class RecipeDetailPage : ContentPage
    {
        RecipeDetailViewModel _viewModel;

        public RecipeDetailPage(RecipeDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }

        public RecipeDetailPage()
        {
            InitializeComponent();

            var item = new Recipe
            {
                // TODO: Is it necessary to set anything here?
                Title = "Is this used???",
            };

            _viewModel = new RecipeDetailViewModel(item);
            BindingContext = _viewModel;
        }
    }
}
