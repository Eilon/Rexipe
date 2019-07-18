using System;
using System.Collections;
using System.Globalization;
using Xamarin.Forms;

namespace RexipeMobile.Converters
{
    public class IsCollectionNotEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var collection = value as ICollection;
            if (value == null)
            {
                return null;
            }
            return collection.Count != 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
