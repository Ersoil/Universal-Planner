using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Universal_Planner.Componets.viewModels;
using Universal_Planner.Componets.Models;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Universal_Planner.Componets.Resources
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class planner : Page
    {
        public planner()
        {
            this.InitializeComponent();
            TaskViewModel TasksView = new TaskViewModel(new List<UTask>
            {
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask(),
                new UTask()
            }
            );
            DataContext = TasksView;
        }
    }
}
