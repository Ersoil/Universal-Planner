using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Universal_Planner.Componets.viewModels;
using System.Diagnostics;

namespace Universal_Planner.Componets.Converters
{
    public sealed class LevelIndent : IValueConverter
    {
        public object Convert(object v, Type t, object p, string lang)
        {
            if (v is TaskViewModel vm)
            {
                int level = 0;
                var cur = vm.Parent;
                while (cur != null) { level++; cur = cur.Parent; }
                return level * 40;            // 0, 40, 80 …
            }
            return 0;
        }
        public object ConvertBack(object v, Type t, object p, string l) => null;
    }
}
