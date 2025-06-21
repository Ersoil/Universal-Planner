using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Universal_Planner.Componets.viewModels;
using System.Diagnostics;
using Windows.UI.Xaml;                

namespace Universal_Planner.Componets.Converters
{
    public sealed class LevelToMargin : Windows.UI.Xaml.Data.IValueConverter
    {
        private const int STEP = 40;

        public object Convert(object value, Type targetType,
                              object parameter, string language)
        {
            if (value is TaskViewModel vm)
            {
                int level = 0;
                for (var p = vm.Parent; p != null; p = p.Parent) level++;

                return new Thickness(level * STEP, 0, 0, 0);
            }
            return new Thickness(0);
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, string language) => null;
    }
}
