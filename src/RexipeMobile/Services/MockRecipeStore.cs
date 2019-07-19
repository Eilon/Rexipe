using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RexipeModels;

namespace RexipeMobile.Services
{
    public class MockRecipeStore : IRecipeStore
    {
        readonly List<Recipe> _recipes;

        public MockRecipeStore()
        {
            _recipes = new List<Recipe>();

            var eilonAuthor = new RecipeAuthor
            {
                Id = 1,
                Name = "Eilon Lipton",
            };
            var otherAuthor = new RecipeAuthor
            {
                Id = 2,
                Name = "Secret Chef",
            };

            var mockRecipes = new List<Recipe>
            {
                new Recipe {
                    Id = 1,
                    Title = "Famous BBQ chicken",
                    CookTime = TimeSpan.FromHours(2.5),
                    PrepTime = TimeSpan.FromHours(0.75),
                    ReadyTime = TimeSpan.FromHours(4),
                    Author = eilonAuthor,
                    ServingsMin = 4,
                    ServingsMax = 6,
                    Ingredients = new List<IngredientQuantity>
                    {
                        new IngredientQuantity{Id=0, Ingredient = new Ingredient{Name="Boneless, skinless chicken breast" }, Quantity = new ItemQuantity{Numerator=3, Denominator=1, Unit=IngredientUnit.Pound } },
                        new IngredientQuantity{Id=1, Ingredient = new Ingredient{Name="Salt" }, Quantity = new ItemQuantity{Numerator=1, Denominator=1, Unit=IngredientUnit.Pinch } },
                        new IngredientQuantity{Id=2, Ingredient = new Ingredient{Name="Potatoes" }, Quantity = new ItemQuantity{Numerator=2, Denominator=1, Unit=IngredientUnit.Pound } },
                        new IngredientQuantity{Id=3, Ingredient = new Ingredient{Name="Celery" }, Quantity = new ItemQuantity{Numerator=4, Denominator=1, Unit=IngredientUnit.Other, OtherUnit="Stalks" } },
                    },
                    Directions = new List<RecipeDirection>
                    {
                        new RecipeDirection{ Id=0, Direction="Chop celery"},
                        new RecipeDirection{ Id=1, Direction="Cut chicken into cubes"},
                        new RecipeDirection{ Id=2, Direction="Chop potatoes into cubes"},
                        new RecipeDirection{ Id=3, Direction="Mix everything"},
                        new RecipeDirection{ Id=4, Direction="Pre-heat oven to 123 degrees"},
                        new RecipeDirection{ Id=5, Direction="Cook for 2 1/2 hours"},
                        new RecipeDirection{ Id=6, Direction="Remove from oven, let sit 15 minutes"},
                    },
                },

                new Recipe {
                    Id = 2,
                    Title = "Awesome lasagna",
                    CookTime = TimeSpan.FromHours(2.5),
                    PrepTime = TimeSpan.FromHours(0.75),
                    ReadyTime = TimeSpan.FromHours(4),
                    Author = eilonAuthor,
                    ServingsMin = 6,
                    ServingsMax = 8,
                    Ingredients = new List<IngredientQuantity>
                    {
                        new IngredientQuantity{Id=4, Ingredient = new Ingredient{Name="Sauce" }, Quantity = new ItemQuantity{Numerator=4, Denominator=1, Unit=IngredientUnit.Other, OtherUnit="16oz can"} },
                        new IngredientQuantity{Id=5, Ingredient = new Ingredient{Name="Lasagna noodle" }, Quantity = new ItemQuantity{Numerator=1, Denominator=1, Unit=IngredientUnit.Other, OtherUnit="Box"} },
                        new IngredientQuantity{Id=6, Ingredient = new Ingredient{Name="Cheese" }, Quantity = new ItemQuantity{Numerator=1, Denominator=1, Unit=IngredientUnit.Pound } },
                    },
                    Directions = new List<RecipeDirection>
                    {
                        new RecipeDirection{ Id=7, Direction="Place layer of noodles in pan"},
                        new RecipeDirection{ Id=8, Direction="Add 1/3 of sauce to pan"},
                        new RecipeDirection{ Id=9, Direction="Add 1/3 of cheese to pan"},
                        new RecipeDirection{ Id=10, Direction="Repeat for 3 total layers"},
                        new RecipeDirection{ Id=11, Direction="Pre-heat oven to 123 degrees"},
                        new RecipeDirection{ Id=12, Direction="Cook for 2 1/2 hours"},
                        new RecipeDirection{ Id=13, Direction="Remove from oven, let sit 15 minutes"},
                    },
                },

                new Recipe {
                    Id = 2,
                    Title = "Apple pie",
                    CookTime = TimeSpan.FromHours(1),
                    PrepTime = TimeSpan.FromHours(0.25),
                    ReadyTime = TimeSpan.FromHours(1.5),
                    Author = otherAuthor,
                    ServingsMin = 8,
                    ServingsMax = 8,
                    Ingredients = new List<IngredientQuantity>
                    {
                        new IngredientQuantity{Id=7, Ingredient = new Ingredient{Name="Granny Smith apples" }, Quantity = new ItemQuantity{Numerator=5, Denominator=1, Unit=IngredientUnit.Pound } },
                        new IngredientQuantity{Id=8, Ingredient = new Ingredient{Name="Sugar" }, Quantity = new ItemQuantity{Numerator=3, Denominator=1, Unit=IngredientUnit.Cup } },
                        new IngredientQuantity{Id=9, Ingredient = new Ingredient{Name="Flour" }, Quantity = new ItemQuantity{Numerator=2, Denominator=1, Unit=IngredientUnit.Pound } },
                        new IngredientQuantity{Id=10, Ingredient = new Ingredient{Name="Salt" }, Quantity = new ItemQuantity{Numerator=2, Denominator=1, Unit=IngredientUnit.Teaspoon } },
                    },
                    Directions = new List<RecipeDirection>
                    {
                        new RecipeDirection{ Id=14, Direction="Chop apples"},
                        new RecipeDirection{ Id=15, Direction="Mix everything in pie pan"},
                        new RecipeDirection{ Id=16, Direction="Pre-heat oven to 123 degrees"},
                        new RecipeDirection{ Id=17, Direction="Cook for 1 hour"},
                        new RecipeDirection{ Id=18, Direction="Remove from oven, let sit 15 minutes"},
                    },
                },

                new Recipe {
                    Id = 3,
                    Title = "Breakfast cereal",
                    CookTime = TimeSpan.FromMinutes(0),
                    PrepTime = TimeSpan.FromMinutes(2),
                    ReadyTime = TimeSpan.FromMinutes(2),
                    Author = otherAuthor,
                    ServingsMin = 1,
                    ServingsMax = 1,
                    Ingredients = new List<IngredientQuantity>
                    {
                        new IngredientQuantity{Id=11, Ingredient = new Ingredient{Name="Milk (any kind)" }, Quantity = new ItemQuantity{Numerator=3, Denominator=2, Unit=IngredientUnit.Cup } },
                        new IngredientQuantity{Id=12, Ingredient = new Ingredient{Name="Cereal (any kind)" }, Quantity = new ItemQuantity{Numerator=1, Denominator=1, Unit=IngredientUnit.Cup } },
                    },
                    Directions = new List<RecipeDirection>
                    {
                        new RecipeDirection{ Id=19, Direction="In clean cereal bowl add cereal of choice"},
                        new RecipeDirection{ Id=20, Direction="Add milk to bowl"},
                        new RecipeDirection{ Id=21, Direction="(Optional) Let sit for 1 minute for cereal to absorb milk"},
                    },
                },

                new Recipe {
                    Id = 4,
                    Title = "Slow cooker chili",
                    CookTime = TimeSpan.FromHours(6),
                    PrepTime = TimeSpan.FromMinutes(5),
                    ReadyTime = TimeSpan.FromHours(6),
                    Author = eilonAuthor,
                    ServingsMin = 8,
                    ServingsMax = 10,
                    Ingredients = new List<IngredientQuantity>
                    {
                        new IngredientQuantity{Id=13, Ingredient = new Ingredient{Name="Pre-made chili" }, Quantity = new ItemQuantity{Numerator=6, Denominator=1, Unit=IngredientUnit.Other, OtherUnit="16oz can"} },
                        new IngredientQuantity{Id=14, Ingredient = new Ingredient{Name="Shredded cheese" }, Quantity = new ItemQuantity{Numerator=1, Denominator=1, Unit=IngredientUnit.Pound } },
                    },
                    Directions = new List<RecipeDirection>
                    {
                        new RecipeDirection{ Id=22, Direction="Add pre-made chili to slow cooker"},
                        new RecipeDirection{ Id=23, Direction="Cook on low for 6 hours"},
                        new RecipeDirection{ Id=24, Direction="Serve and sprinkle cheese as desired"},
                    },
                },
            };

            foreach (var recipe in mockRecipes)
            {
                _recipes.Add(recipe);
            }
        }

        public Task<Recipe> GetRecipeAsync(int recipeId)
        {
            return Task.FromResult(_recipes.FirstOrDefault(s => s.Id == recipeId));
        }

        public Task<IEnumerable<Recipe>> GetAllRecipesAsync(bool forceRefresh = false)
        {
            return Task.FromResult(_recipes.AsEnumerable());
        }

        public Task<IEnumerable<IngredientQuantity>> GetRecipeIngredients(int recipeId)
        {
            return Task.FromResult(_recipes.FirstOrDefault(s => s.Id == recipeId).Ingredients.AsEnumerable());
        }

        public Task<IEnumerable<RecipeDirection>> GetRecipeDirections(int recipeId)
        {
            return Task.FromResult(_recipes.FirstOrDefault(s => s.Id == recipeId).Directions.AsEnumerable());
        }
    }
}
