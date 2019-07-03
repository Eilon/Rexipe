using System;
using System.ComponentModel;
using Xamarin.Forms;
using RexipeModels;

namespace RexipeMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewRecipePage : ContentPage
    {
        public Recipe Recipe { get; set; }

        public NewRecipePage()
        {
            InitializeComponent();

            Recipe = new Recipe
            {
                Id = 100,
                Title = "Great new recipe!!!",
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddRecipe", Recipe);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}