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
using Windows.UI.Popups;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Universal_Planner.Pages
{

    public sealed partial class planner : Page
    {
        public TaskViewModel SelectedTask;
        public planner()
        {
            this.InitializeComponent();
            this.DataContext = GloabalData.Instance;
            TaskViewEdit.DataContext = SelectedTask;
        }

        private void CreateTask_Click(object sender, RoutedEventArgs e)
        {
            GloabalData.Instance.TaskViewList.Add(new TaskViewModel(new UTask()));
        }

        private void TaskListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var selectedTask = e.AddedItems[0] as TaskViewModel; // Замените TaskModel на ваш класс
                if (selectedTask != null)
                {
                    SelectedTask = selectedTask;
                }
            }
        }
    }
}
