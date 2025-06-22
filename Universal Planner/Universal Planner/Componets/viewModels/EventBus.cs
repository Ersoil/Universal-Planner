using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Planner.Componets.viewModels
{
    public static class EventBus
    {
        public static Action<string> onLogChanged;
    }
}
