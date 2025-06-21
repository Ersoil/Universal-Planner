using Windows.UI.Xaml;           // UIElement
using Windows.UI.Xaml.Input;      // DragEventArgs
using Windows.UI.Xaml.Controls;   // ListView
using Windows.UI.Core;            // Dispatcher
using Windows.UI.Xaml.Media;      // Visual feedback
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Data;
using Universal_Planner.Componets.viewModels;
using Universal_Planner.Componets.Models;
using System.Diagnostics;
using System;
using Windows.ApplicationModel.DataTransfer;

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
            GlobalData.Instance.AddTask(new UTask());
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
                    TaskViewEdit.DataContext = e.AddedItems[0];
            }
        }

        private void DeadlineFlyout_Opened(object sender, object e)
        {
            var flyout = (Flyout)sender;

            var root = flyout.Content as FrameworkElement;
            if (root != null)
                root.DataContext = TaskListView.SelectedItem;
        }

        // helper: вернуть количество прямых и вложенных потомков
        private int CountDescendants(TaskViewModel parent)
        {
            var list = GlobalData.Instance.TaskViewList;
            int pos = list.IndexOf(parent) + 1;
            int count = 0;

            while (pos < list.Count && IsDescendant(list[pos], parent))
            {
                count++;
                pos++;
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

        // 2.1  кладём ссылку на VM в DataPackage
        private void TaskListView_DragItemsStarting(object sender,
                                                    DragItemsStartingEventArgs e)
        {
            if (e.Items.Count == 0) return;

            int index = TaskListView.Items.IndexOf(e.Items[0]);
            e.Data.SetText(index.ToString());
            e.Data.RequestedOperation =
                Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
        }

        // 2. Subtask зона принимает только Move
        private void SubtaskZone_DragOver(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
                e.AcceptedOperation = DataPackageOperation.Move;
            else
                e.AcceptedOperation = DataPackageOperation.None;
        }

        // 3. Drop → превращаем выбранную задачу в «дитя» текущего SelectedItem
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

            // если уже потомок выбранного – ничего
            if (IsDescendant(child, parent) || child == parent)
            { def.Complete(); return; }

            // 1) снимаем старую связь и удаляем блок потомков из списка
            RemoveWithDescendants(child);

            // 2) вычисляем новую позицию = конец блока потомков родителя
            int insertPos = list.IndexOf(parent) + 1 + CountDescendants(parent);

            list.Insert(insertPos, child);
            child.AttachToParent(parent);

            def.Complete();
        }

        // удаляет элемент и всех его потомков
        private void RemoveWithDescendants(TaskViewModel item)
        {
            var list = GlobalData.Instance.TaskViewList;
            int start = list.IndexOf(item);
            int count = 1 + CountDescendants(item);
            for (int i = start; i < count; i++) GlobalData.Instance.DeleteTask(GlobalData.Instance.TaskViewList[i].Id);
        }


        // 2.2  показываем, что зона принимает «Move»
        private void TrashZone_DragOver(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(Windows.ApplicationModel.DataTransfer.StandardDataFormats.Text))
            {
                e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
                TrashZone.Opacity = 0.8;          // визуальная подсветка
            }
            else
                e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;
        }

        // 2.3  по Drop удаляем задачу из коллекции
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
    }
}
