using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Universal_Planner.Componets.Models;

namespace Universal_Planner.Componets.viewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private UTask ModelTask;
        public TaskViewModel Parent { get; private set; }

        public ObservableCollection<TaskViewModel> SubTasks { get; } = new ObservableCollection<TaskViewModel>();
        public ObservableCollection<UTaskTag> TaskTags { get; }= new ObservableCollection<UTaskTag>();
        public ObservableCollection<UTag> Tags { get; }= new ObservableCollection<UTag>();

        public TaskViewModel(UTask task, TaskViewModel parent = null)
        {
            ModelTask = task;
            Parent = parent;

            // Инициализация подзадач из модели
            if (task.SubTasks != null)
            {
                foreach (var subTask in task.SubTasks)
                {
                    SubTasks.Add(new TaskViewModel(subTask, this));
                }
            }
        }

        public void AttachToParent(TaskViewModel parent)
        {
            // Удаляем из текущего родителя
            Parent?.SubTasks.Remove(this);

            // Обновляем модель
            ModelTask.ParentTaskId = parent?.Id;
            ModelTask.ParentTask = parent?.ModelTask;

            // Устанавливаем нового родителя
            Parent = parent;
            parent?.SubTasks.Add(this);

            onPropertyChanged(nameof(Parent));
            onPropertyChanged(nameof(IsSubtask));
            GlobalData.Instance.UpdateTask(ModelTask);
        }

        private void RefreshTags()
        {
            Tags.Clear();
            foreach (var link in TaskTags)
                Tags.Add(link.Tag);
            onPropertyChanged(nameof(Tags));
        }

        public void AddTag(UTag tag)
        {
            // предотвращаем дубли
            if (TaskTags.Any(link => link.TagId == tag.Id)) return;

            var tt = new UTaskTag { Task = ModelTask, Tag = tag };
            TaskTags.Add(tt);
            ModelTask.TaskTags.Add(tt);
            RefreshTags();
        }

        public void RemoveTag(UTag tag)
        {
            var link = TaskTags.FirstOrDefault(x => x.TagId == tag.Id);
            if (link == null) return;
            TaskTags.Remove(link);
            ModelTask.TaskTags.Remove(link);
            RefreshTags();
        }

        public void AddSubTask(TaskViewModel subTask)
        {
            subTask.AttachToParent(this);
            ModelTask.SubTasks.Add(subTask.ModelTask);
            GlobalData.Instance.UpdateTask(ModelTask);
            EventBus.onLogChanged?.Invoke($"Добавленна подзадача '{subTask.Title}' для '{ModelTask.Title}'");
        }

        public void RemoveSubTask(TaskViewModel subTask)
        {
            if (SubTasks.Contains(subTask))
            {
                SubTasks.Remove(subTask);
                ModelTask.SubTasks.Remove(subTask.ModelTask);
                subTask.Parent = null;
                subTask.ModelTask.ParentTaskId = null;
                subTask.ModelTask.ParentTask = null;
                GlobalData.Instance.UpdateTask(subTask.ModelTask);
                GlobalData.Instance.UpdateTask(ModelTask);
            }
        }

        public bool IsSubtask => Parent != null;

        public int Id => ModelTask.Id;

        public string Title
        {
            get => ModelTask.Title;
            set
            {
                var oldTitle = ModelTask.Title;
                ModelTask.Title = value;
                onPropertyChanged(nameof(Title));
                GlobalData.Instance.UpdateTask(ModelTask);
                EventBus.onLogChanged?.Invoke($"Смена имени задачи с '{oldTitle}' для '{ModelTask.Title}'");
            }
        }

        public string Description
        {
            get => ModelTask.Description;
            set
            {
                var oldDesc = ModelTask.Description;
                ModelTask.Description = value;
                onPropertyChanged(nameof(Description));
                GlobalData.Instance.UpdateTask(ModelTask);
                EventBus.onLogChanged?.Invoke($"Смена описания с '{oldDesc}' для '{ModelTask.Description}'");
            }
        }

        public DateTime DueDate
        {
            get => ModelTask.DueDate;
            set
            {
                ModelTask.DueDate = value;
                onPropertyChanged(nameof(DueDate));
                onPropertyChanged(nameof(DatePart));
                onPropertyChanged(nameof(TimePart));
                GlobalData.Instance.UpdateTask(ModelTask);
                EventBus.onLogChanged?.Invoke($"Изменено время на'{ModelTask.DueDate}' для '{ModelTask.Title}'");
            }
        }

        public bool IsCompleted
        {
            get => ModelTask.IsCompleted;
            set
            {
                ModelTask.IsCompleted = value;
                onPropertyChanged(nameof(IsCompleted));
                GlobalData.Instance.UpdateTask(ModelTask);
                EventBus.onLogChanged?.Invoke($"Изменен статус задачи IsCompleted: '{ModelTask.IsCompleted}' для '{ModelTask.Title}'");

                if (value && SubTasks.Any())
                {
                    foreach (var subTask in SubTasks)
                    {
                        subTask.IsCompleted = true;
                    }
                }
            }
        }

        public DateTimeOffset DatePart
        {
            get
            {
                var safeDate = (DueDate == DateTime.MinValue) ? DateTime.Today : DueDate.Date;
                return new DateTimeOffset(safeDate);
            }
            set { DueDate = value.Date + TimePart;
                EventBus.onLogChanged?.Invoke($"Изменено время на'{ModelTask.DueDate}' для '{ModelTask.Title}'");
            }

        }

        public TimeSpan TimePart
        {
            get => DueDate.TimeOfDay;
            set {
                DueDate = DatePart.Date + value;
                EventBus.onLogChanged?.Invoke($"Изменено время на'{ModelTask.DueDate}' для '{ModelTask.Title}'");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        // Метод для получения модели (может пригодиться)
        public UTask GetModel() => ModelTask;
    }
}