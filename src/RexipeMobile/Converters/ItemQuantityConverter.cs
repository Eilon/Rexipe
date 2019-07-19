using RexipeModels;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace RexipeMobile.Converters
{
    public class ItemQuantityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ItemQuantity itemQuantity))
            {
                return null;
            }

            return itemQuantity.GetItemQuantity();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
