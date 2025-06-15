using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universal_Planner.Componets.Models;

namespace Universal_Planner.Componets.viewModels
{
    public static class GloabalData
    {
        public static List<UTask> TaskList = new List<UTask>() {
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask()
        };
        private static List<UTag> TagList;
        private static List<Uuser> UserList;
        private static List<UTaskTag> TaskTags;


    }
}
