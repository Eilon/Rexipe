using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RexipeModels
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public List<IngredientQuantity> Ingredients { get; set; }
        public List<RecipeDirection> Directions { get; set; }
        public int ServingsMin { get; set; }
        public int ServingsMax { get; set; }
        public List<RecipeTip> Tips { get; set; }
        public List<Image> Images { get; set; }
        public NutritionInfo NutritionInfo { get; set; }
        public TimeSpan PrepTime { get; set; }
        public TimeSpan CookTime { get; set; }
        public TimeSpan ReadyTime { get; set; }
        [Required]
        public RecipeAuthor Author { get; set; }
        // TODO: Add list of special items needed (e.g. slow cooker, pans, etc.)
        // TODO: Add tags/keywords
    }

    public class NutritionInfo
    {
        public int Id { get; set; }
        public int Calories { get; set; }

        // TODO: More nutrition info
    }

    public class RecipeAuthor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class RecipeTip
    {
        public int Id { get; set; }
        public int Order { get; set; }
        [Required]
        public string Text { get; set; }
        public Image Image { get; set; }
    }

    public class RecipeDirection
    {
        public int Id { get; set; }
        public int Order { get; set; }
        [Required]
        public string Direction { get; set; }
        // TODO: Ingredient references
    }

    public class IngredientQuantity
    {
        public int Id { get; set; }
        public int Order { get; set; }
        [Required]
        public Ingredient Ingredient { get; set; }
        public ItemQuantity Quantity { get; set; }
    }

    public class Ingredient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Image Image { get; set; }
    }

    public class Image
    {
        public int Id { get; set; }
        public string Caption { get; set; }

        // TODO: What type to use for this?
        [Required]
        public byte[] Bytes { get; set; }
    }

    public class ItemQuantity
    {
        public int Id { get; set; }
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public IngredientUnit Unit { get; set; }
        public string OtherUnit { get; set; }
        public string GetItemQuantity()
        {
            // TODO: Do proper language display of text
            // TODO: Localize unit display
            // TODO: Automatically do smart fractions (e.g. 7/2 --> 3 1/2)
            var unitString = Unit == IngredientUnit.Other ? OtherUnit : Unit.ToString();
            if (Denominator == 1)
            {
                return $"{Numerator} {unitString}";
            }
            else
            {
                return $"{Numerator}/{Denominator} {unitString}";
            }
        }
    }

    public enum IngredientUnit
    {
        Other = 10,

        // --- WEIGHT ---

        // Non-metric weight
        Ounce = 110,
        Pound = 120,

        // Metric weight
        Milligram = 210,
        Gram = 220,
        Kilogram = 230,


        // --- VOLUME ---

        // Non-metric volume
        FluidOunce = 310,
        Cup = 320,
        Pint = 330,
        Quart = 340,
        Gallon = 350,

        // Metric volume
        Milliliter = 410,
        Centiliter = 420,
        Deciliter = 430,
        Liter = 440,

        Teaspoon = 510,
        Tablespoon = 520,

        // --- LENGTH ---

        // Metric length
        Millimeter = 610,
        Centimeter = 620,
        Meter = 630,

        // Non-metric length
        Inch = 710,
        Foot = 720,

        // --- MISC ---
        Pinch = 810,
        Dash = 820,
    }
}
