using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Core;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Data;
using Universal_Planner.Componets.viewModels;
using Universal_Planner.Componets.Models;
using System.Diagnostics;
using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Popups;

namespace Universal_Planner.Pages
{
    public sealed partial class planner : Page
    {
        public TaskViewModel SelectedTask;
        public planner()
        {
            this.InitializeComponent();
            DataContext = GlobalData.Instance;
        }

        private void CreateTask()
        {
            var newTask = new UTask();
            GlobalData.Instance.AddTask(newTask);
            EventBus.onLogChanged?.Invoke($"Создана задача '{newTask.Title}'");
        }

        public void CreateTask_Click(object sender, RoutedEventArgs e)
        {
            CreateTask();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is string param && param == "create")
            {
                Debug.WriteLine("[Planner] Received 'create' parameter. Creating new task...");
                CreateTask();
            }
        }

        private void TaskListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var selectedTask = e.AddedItems[0] as TaskViewModel;
                if (selectedTask != null)
                {
                    SelectedTask = selectedTask;
                }
                if (e.AddedItems.Count > 0)
                    TaskViewEdit.DataContext = SelectedTask;
                SubtasksListView.ItemsSource = SelectedTask.SubTasks;
            }
        }

        private void DeadlineFlyout_Opened(object sender, object e)
        {
            var flyout = (Flyout)sender;
            var root = flyout.Content as FrameworkElement;
            if (root != null)
                root.DataContext = TaskListView.SelectedItem;
        }

        private int CountDescendants(TaskViewModel parent)
        {
            int count = parent.SubTasks.Count;
            foreach (var child in parent.SubTasks)
            {
                count += CountDescendants(child);
            }
            return count;
        }


        private bool IsDescendant(TaskViewModel child, TaskViewModel ancestor)
        {
            var cur = child.Parent;
            while (cur != null)
            {
                if (cur == ancestor) return true;
                cur = cur.Parent;
            }
            return false;
        }

        private void TaskListView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            if (e.Items.Count == 0) return;

            int index = TaskListView.Items.IndexOf(e.Items[0]);
            e.Data.SetText(index.ToString());
            e.Data.RequestedOperation = DataPackageOperation.Move;
        }


        private void SubtaskZone_DragOver(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
                e.AcceptedOperation = DataPackageOperation.Move;
            else
                e.AcceptedOperation = DataPackageOperation.None;
        }

        private async void SubtaskZone_Drop(object sender, DragEventArgs e)
        {
            var def = e.GetDeferral();
            var list = GlobalData.Instance.TaskViewList;

            string txt = await e.DataView.GetTextAsync();
            if (!int.TryParse(txt, out int oldIndex) || oldIndex < 0 || oldIndex >= list.Count)
            { def.Complete(); return; }

            if (!(TaskListView.SelectedItem is TaskViewModel parent))
            { def.Complete(); return; }

            var child = list[oldIndex];

            if (IsDescendant(child, parent) || child == parent)
            { def.Complete(); return; }

            list.RemoveAt(oldIndex);
            parent.AddSubTask(child);

            def.Complete();
        }

        private void RemoveWithDescendants(TaskViewModel item)
        {
            if (item.Parent != null)
            {
                item.Parent.RemoveSubTask(item);
            }
            else
            {
                GlobalData.Instance.TaskViewList.Remove(item);
                GlobalData.Instance.DeleteTask(item.Id);
            }
        }


        private void TrashZone_DragOver(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                e.AcceptedOperation = DataPackageOperation.Move;
                TrashZone.Opacity = 0.8;
            }
            else
                e.AcceptedOperation = DataPackageOperation.None;
        }


        private async void TrashZone_Drop(object sender, DragEventArgs e)
        {
            TrashZone.Opacity = 1;
            if (!e.DataView.Contains(StandardDataFormats.Text)) return;

            var def = e.GetDeferral();
            var list = GlobalData.Instance.TaskViewList;
            string txt = await e.DataView.GetTextAsync();

            if (int.TryParse(txt, out int index) && index >= 0 && index < list.Count)
                RemoveWithDescendants(list[index]);

            def.Complete();
        }
        private void AddTagButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            // Создаём меню на лету
            var flyout = new MenuFlyout();

            foreach (var tag in GlobalData.Instance.TagViewLList)
            {
                var mi = new MenuFlyoutItem { Text = tag.Name, Tag = tag };
                mi.Click += (s, ev) =>
                {
                    if (TaskListView.SelectedItem is TaskViewModel vm)
                        vm.AddTag((UTag)mi.Tag);
                };
                flyout.Items.Add(mi);
            }

            // Показываем рядом с кнопкой
            btn.Flyout = flyout;
            flyout.ShowAt(btn);
        }
    }
}