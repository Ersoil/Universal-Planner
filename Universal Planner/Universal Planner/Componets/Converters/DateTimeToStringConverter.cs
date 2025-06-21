using System;
using Windows.UI.Xaml.Data;

namespace Universal_Planner.Componets.Converters
{
    public sealed class DateTimeToStringConverter : IValueConverter
    {
        /// <summary>Формат по умолчанию</summary>
        public string Format { get; set; } = "dd.MM.yyyy HH:mm";

        public object Convert(object value, Type t, object parameter, string lang)
        {
            if (value is DateTime dt && dt > DateTime.MinValue)
            {
                string fmt = parameter as string ?? Format;
                return dt.ToString(fmt);
            }
            return "";         // пустая строка, если даты нет
        }

        public object ConvertBack(object value, Type t, object parameter, string lang)
            => throw new NotImplementedException();   // обратное преобразование не нужно
    }
}
