using System;
using System.Collections.ObjectModel;
using System.Linq;
using Universal_Planner.Componets.Models;
using Universal_Planner.Componets.Data;

namespace Universal_Planner.Componets.viewModels
{
    public class GlobalData
    {
        public ObservableCollection<TaskViewModel> TaskViewList { get; set; }
        public ObservableCollection<UTag> TagViewLList { get; set; }
        public ObservableCollection<Uuser> UserViewLList { get; set; }
        private static GlobalData _Instance;
        private readonly AppDbContext _dbContext;

        private GlobalData()
        {
            _dbContext = new AppDbContext();
            _dbContext.Database.EnsureCreated(); // Создаем БД, если ее нет

            // Загружаем задачи из базы данных
            var tasks = _dbContext.Tasks.ToList();
            TaskViewList = new ObservableCollection<TaskViewModel>(
                tasks.Select(t => new TaskViewModel(t)));

            TagViewLList = new ObservableCollection<UTag>();
            UserViewLList = new ObservableCollection<Uuser>();
        }

        public static GlobalData Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GlobalData();
                }
                return _Instance;
            }
        }

        // Методы для работы с базой данных
        public void AddTask(UTask task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
            TaskViewList.Add(new TaskViewModel(task));
        }

        public void UpdateTask(UTask task)
        {
            _dbContext.Tasks.Update(task);
            _dbContext.SaveChanges();

            // Обновляем ViewModel
            var vm = TaskViewList.FirstOrDefault(t => t.Id == task.Id);
            if (vm != null)
            {
                vm.Title = task.Title;
                vm.Description = task.Description;
                vm.DueDate = task.DueDate;
            }
        }

        public void DeleteTask(int taskId)
        {
            var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
                _dbContext.SaveChanges();

                var vm = TaskViewList.FirstOrDefault(t => t.Id == taskId);
                if (vm != null)
                {
                    TaskViewList.Remove(vm);
                }
            }
        }
    }
}