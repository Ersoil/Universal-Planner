using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universal_Planner.Componets.Models;
using System.ComponentModel;

namespace Universal_Planner.Componets.viewModels
{
    class TaskViewModel: INotifyPropertyChanged
    {
        public UTask ModelTask;
        public ObservableCollection<TaskViewModel> TaskViewList { get; set; }

        public TaskViewModel(UTask task)
        {
           ModelTask = task;
        }

        public TaskViewModel(List<UTask> tasks)
        {
            TaskViewList = new ObservableCollection<TaskViewModel>(tasks.Select(b => new TaskViewModel(b)));
        }

        public string Title
        {
            get
            {
                return ModelTask.Title;
            }
            set
            {
                ModelTask.Title = value;
                onPropertyChanged("Title");
            }
        }
        public string Description
        {
            get
            {
                return ModelTask.Description;
            }
            set
            {
                ModelTask.Description = value;
                onPropertyChanged("Description");
            }
        }
        public DateTime DueDate
        {
            get
            {
                return ModelTask.DueDate;
            }
            set
            {
                ModelTask.DueDate = value;
                onPropertyChanged("DueTime");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
