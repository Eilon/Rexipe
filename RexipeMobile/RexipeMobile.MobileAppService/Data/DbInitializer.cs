using RexipeModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RexipeMobile.MobileAppService.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RexipeDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Recipes.Any())
            {
                return;   // DB has been seeded
            }

            var authors = new []
            {
                new RecipeAuthor
                {
                    /*Id = 1,*/
                    Name = "DB Eilon Lipton",
                },
                new RecipeAuthor
                {
                    /*Id = 2,*/
                    Name = "DB Secret Chef",
                },
            };
            foreach (var a in authors)
            {
                context.RecipeAuthors.Add(a);
            }
            context.SaveChanges();

            var quantities = new[]
            {
                new ItemQuantity { Numerator = 3, Denominator = 1, Unit = IngredientUnit.Pound },
                new ItemQuantity { Numerator = 1, Denominator = 1, Unit = IngredientUnit.Pinch },
                new ItemQuantity { Numerator = 2, Denominator = 1, Unit = IngredientUnit.Pound },
                new ItemQuantity { Numerator = 4, Denominator = 1, Unit = IngredientUnit.Other, OtherUnit = "Stalks" },

                new ItemQuantity{Numerator=4, Denominator=1, Unit=IngredientUnit.Other, OtherUnit="16oz can"},
                new ItemQuantity{Numerator=1, Denominator=1, Unit=IngredientUnit.Other, OtherUnit="Box"},
                new ItemQuantity{Numerator=1, Denominator=1, Unit=IngredientUnit.Pound },

                new ItemQuantity{Numerator=5, Denominator=1, Unit=IngredientUnit.Pound },
                new ItemQuantity{Numerator=3, Denominator=1, Unit=IngredientUnit.Cup },
                new ItemQuantity { Numerator = 2, Denominator = 1, Unit = IngredientUnit.Pound },
                new ItemQuantity{Numerator=2, Denominator=1, Unit=IngredientUnit.Teaspoon },

                new ItemQuantity{Numerator=3, Denominator=2, Unit=IngredientUnit.Cup },
                new ItemQuantity { Numerator = 1, Denominator = 1, Unit = IngredientUnit.Cup },

                new ItemQuantity{Numerator=6, Denominator=1, Unit=IngredientUnit.Other, OtherUnit="16oz can"},
                 new ItemQuantity { Numerator = 1, Denominator = 1, Unit = IngredientUnit.Pound },
            };
            foreach (var q in quantities)
            {
                context.ItemQuantities.Add(q);
            }
            context.SaveChanges();


            var ingredients = new[]
            {
                  new Ingredient { Name = "Boneless, skinless chicken breast" },
                  new Ingredient { Name = "Salt" },
                  new Ingredient { Name = "Potatoes" },
                 new Ingredient { Name = "Celery" },

                new Ingredient { Name="Sauce" },
                new Ingredient { Name="Lasagna noodle" },
                new Ingredient { Name="Cheese" },

                new Ingredient { Name="Granny Smith apples" },
                new Ingredient { Name="Sugar" },
                new Ingredient { Name="Flour" },
                new Ingredient{Name="Salt" },

                new Ingredient{Name="Milk (any kind)" },
                new Ingredient{Name="Cereal (any kind)" },

                new Ingredient{Name="Pre-made chili" },
                new Ingredient{Name="Shredded cheese" },
            };
            foreach (var i in ingredients)
            {
                context.Ingredients.Add(i);
            }
            context.SaveChanges();


            var ingredientQuantities = new[]
            {
                new IngredientQuantity { /*Id = 0,*/ Ingredient = ingredients[0], Quantity =quantities[0]  },
                new IngredientQuantity { /*Id = 1,*/ Ingredient = ingredients[1], Quantity =  quantities[1]},
                new IngredientQuantity { /*Id = 2,*/ Ingredient = ingredients[2], Quantity =  quantities[2]},
                new IngredientQuantity { /*Id = 3,*/ Ingredient = ingredients[3], Quantity =  quantities[3]},

                new IngredientQuantity{/*Id=4,*/ Ingredient = ingredients[4], Quantity =  quantities[4]},
                new IngredientQuantity{/*Id=5,*/ Ingredient = ingredients[5], Quantity =  quantities[5]},
                new IngredientQuantity{/*Id=6,*/ Ingredient = ingredients[6], Quantity =  quantities[6]},

                new IngredientQuantity{/*Id=7,*/ Ingredient = ingredients[7], Quantity =  quantities[7]},
                new IngredientQuantity{/*Id=8,*/ Ingredient = ingredients[8], Quantity = quantities[8]},
                new IngredientQuantity{/*Id=9,*/ Ingredient = ingredients[9], Quantity = quantities[9]},
                new IngredientQuantity{/*Id=10,*/ Ingredient = ingredients[10], Quantity = quantities[10]},

                new IngredientQuantity{/*Id=11,*/ Ingredient = ingredients[11], Quantity = quantities[11]},
                new IngredientQuantity{/*Id=12,*/ Ingredient = ingredients[12], Quantity =  quantities[12]},

                new IngredientQuantity{/*Id=13,*/ Ingredient = ingredients[13], Quantity = quantities[13]},
                new IngredientQuantity{/*Id=14,*/ Ingredient = ingredients[14], Quantity = quantities[14]},
            };
            foreach (var iq in ingredientQuantities)
            {
                context.IngredientQuantities.Add(iq);
            }
            context.SaveChanges();


            var directions = new[]
            {
                new RecipeDirection{ /*Id=0,*/ Direction="Chop celery"},
                new RecipeDirection{ /*Id=1,*/ Direction="Cut chicken into cubes"},
                new RecipeDirection{ /*Id=2,*/ Direction="Chop potatoes into cubes"},
                new RecipeDirection{ /*Id=3,*/ Direction="Mix everything"},
                new RecipeDirection{ /*Id=4,*/ Direction="Pre-heat oven to 123 degrees"},
                new RecipeDirection{ /*Id=5,*/ Direction="Cook for 2 1/2 hours"},
                new RecipeDirection{ /*Id=6,*/ Direction="Remove from oven, let sit 15 minutes"},

                new RecipeDirection{ /*Id=7,*/ Direction="Place layer of noodles in pan"},
                new RecipeDirection{ /*Id=8,*/ Direction="Add 1/3 of sauce to pan"},
                new RecipeDirection{ /*Id=9,*/ Direction="Add 1/3 of cheese to pan"},
                new RecipeDirection{ /*Id=10,*/ Direction="Repeat for 3 total layers"},
                new RecipeDirection{ /*Id=11,*/ Direction="Pre-heat oven to 123 degrees"},
                new RecipeDirection{ /*Id=12,*/ Direction="Cook for 2 1/2 hours"},
                new RecipeDirection{ /*Id=13,*/ Direction="Remove from oven, let sit 15 minutes"},

                new RecipeDirection{ /*Id=14,*/ Direction="Chop apples"},
                new RecipeDirection{ /*Id=15,*/ Direction="Mix everything in pie pan"},
                new RecipeDirection{ /*Id=16,*/ Direction="Pre-heat oven to 123 degrees"},
                new RecipeDirection{ /*Id=17,*/ Direction="Cook for 1 hour"},
                new RecipeDirection{ /*Id=18,*/ Direction="Remove from oven, let sit 15 minutes"},

                new RecipeDirection{ /*Id=19,*/ Direction="In clean cereal bowl add cereal of choice"},
                new RecipeDirection{ /*Id=20,*/ Direction="Add milk to bowl"},
                new RecipeDirection{ /*Id=21,*/ Direction="(Optional) Let sit for 1 minute for cereal to absorb milk"},

                new RecipeDirection{ /*Id=22,*/ Direction="Add pre-made chili to slow cooker"},
                new RecipeDirection{ /*Id=23,*/ Direction="Cook on low for 6 hours"},
                new RecipeDirection{ /*Id=24,*/ Direction="Serve and sprinkle cheese as desired"},
            };
            foreach (var d in directions)
            {
                context.RecipeDirections.Add(d);
            }
            context.SaveChanges();


            var recipes = new[]
            {
                new Recipe {
                    /*Id = 1,*/
                    Title = "DB Famous BBQ chicken",
                    CookTime = TimeSpan.FromHours(2.5),
                    PrepTime = TimeSpan.FromHours(0.75),
                    ReadyTime = TimeSpan.FromHours(4),
                    Author = authors[0],
                    ServingsMin = 4,
                    ServingsMax = 6,
                    Ingredients = ingredientQuantities.Skip(0).Take(4).ToList(),
                    Directions = directions.Skip(0).Take(7).ToList(),
                },

                new Recipe {
                    /*Id = 2,*/
                    Title = "DB Awesome lasagna",
                    CookTime = TimeSpan.FromHours(2.5),
                    PrepTime = TimeSpan.FromHours(0.75),
                    ReadyTime = TimeSpan.FromHours(4),
                    Author = authors[0],
                    ServingsMin = 6,
                    ServingsMax = 8,
                    Ingredients = ingredientQuantities.Skip(4).Take(3).ToList(),
                    Directions = directions.Skip(7).Take(7).ToList(),
                },

                new Recipe {
                    /*Id = 2,*/
                    Title = "DB Apple pie",
                    CookTime = TimeSpan.FromHours(1),
                    PrepTime = TimeSpan.FromHours(0.25),
                    ReadyTime = TimeSpan.FromHours(1.5),
                    Author = authors[1],
                    ServingsMin = 8,
                    ServingsMax = 8,
                    Ingredients = ingredientQuantities.Skip(7).Take(4).ToList(),
                    Directions = directions.Skip(14).Take(5).ToList(),
                },

                new Recipe {
                    /*Id = 3,*/
                    Title = "DB Breakfast cereal",
                    CookTime = TimeSpan.FromMinutes(0),
                    PrepTime = TimeSpan.FromMinutes(2),
                    ReadyTime = TimeSpan.FromMinutes(2),
                    Author = authors[1],
                    ServingsMin = 1,
                    ServingsMax = 1,
                    Ingredients = ingredientQuantities.Skip(11).Take(2).ToList(),
                    Directions = directions.Skip(19).Take(3).ToList(),
                },

                new Recipe {
                    /*Id = 4,*/
                    Title = "DB Slow cooker chili",
                    CookTime = TimeSpan.FromHours(6),
                    PrepTime = TimeSpan.FromMinutes(5),
                    ReadyTime = TimeSpan.FromHours(6),
                    Author = authors[0],
                    ServingsMin = 8,
                    ServingsMax = 10,
                    Ingredients = ingredientQuantities.Skip(13).Take(2).ToList(),
                    Directions = directions.Skip(22).Take(3).ToList(),
                },
            };
            foreach (var r in recipes)
            {
                context.Recipes.Add(r);
            }
            context.SaveChanges();
        }
    }
}