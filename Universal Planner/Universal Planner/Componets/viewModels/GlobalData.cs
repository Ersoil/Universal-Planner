using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universal_Planner.Componets.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Universal_Planner.Componets.viewModels
{

    public class GlobalData
    {
        public ObservableCollection<TaskViewModel> TaskViewList { get; set; }
        public ObservableCollection<UTag> TagViewLList { get; set; }
        public ObservableCollection<Uuser> UserViewLList { get; set; }
        private static GlobalData _Instance;

        private GlobalData()
        {
            TaskViewList = new ObservableCollection<TaskViewModel>();
            TagViewLList = new ObservableCollection<UTag>();
            UserViewLList = new ObservableCollection<Uuser>();
        }

        public static GlobalData Instance
        {
            get {
                if (_Instance == null)
                {
                    _Instance = new GlobalData();
                }
                return _Instance;
            }
        }
    }
}
