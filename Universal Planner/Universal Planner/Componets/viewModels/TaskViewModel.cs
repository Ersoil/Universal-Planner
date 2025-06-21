using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Universal_Planner.Componets.Models;

namespace Universal_Planner.Componets.viewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private UTask ModelTask;
        public TaskViewModel Parent { get; private set; }

        public ObservableCollection<TaskViewModel> SubTasks { get; } = new ObservableCollection<TaskViewModel>();

        public TaskViewModel(UTask task)
        {
            ModelTask = task;
        }

        public void AttachToParent(TaskViewModel parent)
        {
            Parent?.SubTasks.Remove(this);

            Parent = parent;
            parent?.SubTasks.Add(this);

            onPropertyChanged(nameof(Parent));
            onPropertyChanged(nameof(IsSubtask));
        }

        public bool IsSubtask => Parent != null;

        public int Id => ModelTask.Id;

        public string Title
        {
            get => ModelTask.Title;
            set
            {
                ModelTask.Title = value;
                onPropertyChanged(nameof(Title));
                GlobalData.Instance.UpdateTask(ModelTask);
            }
        }

        public string Description
        {
            get => ModelTask.Description;
            set
            {
                ModelTask.Description = value;
                onPropertyChanged(nameof(Description));
                GlobalData.Instance.UpdateTask(ModelTask);
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
            }
        }
        public DateTimeOffset DatePart
        {
            get
            {
                var safeDate = (DueDate == DateTime.MinValue) ? DateTime.Today : DueDate.Date;
                return new DateTimeOffset(safeDate);
            }
            set => DueDate = value.Date + TimePart;
        }

        public TimeSpan TimePart
        {
            get => DueDate.TimeOfDay;
            set => DueDate = DatePart.Date + value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

