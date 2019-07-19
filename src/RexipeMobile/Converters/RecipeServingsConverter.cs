using RexipeModels;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace RexipeMobile.Converters
{
    public class RecipeServingsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var recipe = value as Recipe;
            if (recipe == null)
            {
                return null;
            }

            if (recipe.ServingsMin == recipe.ServingsMax)
            {
                return recipe.ServingsMin.ToString(culture);
            }
            else
            {
                return string.Format(culture, "{0} - {1}", recipe.ServingsMin, recipe.ServingsMax);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
