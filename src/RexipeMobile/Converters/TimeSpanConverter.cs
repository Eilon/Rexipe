using RexipeModels;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace RexipeMobile.Converters
{
    public class TimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TimeSpan))
            {
                return null;
            }
            var timeSpan = (TimeSpan)value;

            if (timeSpan.TotalMinutes > 60)
            {
                if (timeSpan.Minutes == 0)
                {
                    return string.Format(culture, "{0}hr", timeSpan.Hours);
                }
                else
                {
                    return string.Format(culture, "{0}hr {1}min", timeSpan.Hours, timeSpan.Minutes);
                }
            }
            else
            {
                return string.Format(culture, "{0}min", timeSpan.Minutes);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
