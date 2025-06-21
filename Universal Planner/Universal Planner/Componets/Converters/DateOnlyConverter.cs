using System;
using Windows.UI.Xaml.Data;

namespace Universal_Planner.Componets.Converters
{
    public sealed class DateOnlyConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, string l)
            => new DateTimeOffset(((DateTime)value).Date);

        public object ConvertBack(object value, Type t, object p, string lang)
        {
            if (value is DateTimeOffset dto)
            {
                var old = (DateTime)p;
                return dto.Date + old.TimeOfDay;
            }
            return DateTime.MinValue;
        }
    }
}
