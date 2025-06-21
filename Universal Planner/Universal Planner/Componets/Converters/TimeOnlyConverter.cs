using System;
using Windows.UI.Xaml.Data;

namespace Universal_Planner.Componets.Converters
{
    public sealed class TimeOnlyConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, string l)
            => ((DateTime)value).TimeOfDay;

        public object ConvertBack(object value, Type t, object p, string l)
        {
            var baseDate = (DateTime)p;
            return baseDate.Date + (TimeSpan)value;
        }
    }
}
