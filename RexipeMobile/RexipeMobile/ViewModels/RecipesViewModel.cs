﻿using RexipeMobile.Services;
using RexipeMobile.Views;
using RexipeModels;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RexipeMobile.ViewModels
{
    public class RecipesViewModel : BaseViewModel
    {
        public IRecipeStore DataStore => DependencyService.Get<IRecipeStore>();

        public ObservableCollection<Recipe> Recipes { get; set; }
        public Command LoadRecipesCommand { get; set; }

        public RecipesViewModel()
        {
            Title = "Browse";
            Recipes = new ObservableCollection<Recipe>();
            LoadRecipesCommand = new Command(async () => await ExecuteLoadRecipesCommand());

            MessagingCenter.Subscribe<NewRecipePage, Recipe>(this, "AddRecipe", async (obj, recipe) =>
            {
                var newRecipe = recipe as Recipe;
                Recipes.Add(newRecipe);
                await DataStore.AddRecipeAsync(newRecipe);
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
                var recipes = await DataStore.GetRecipeAsync(true);
                foreach (var recipe in recipes)
                {
                    Recipes.Add(recipe);
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