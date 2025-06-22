using System;
using System.Collections.ObjectModel;
using System.Linq;
using Universal_Planner.Componets.Models;
using Universal_Planner.Componets.Data;
using System.Threading.Tasks;

namespace Universal_Planner.Componets.viewModels
{
    public class GlobalData
    {
        public ObservableCollection<TaskViewModel> TaskViewList { get; set; }
        public ObservableCollection<UTag> TagViewLList { get; set; }
        public ObservableCollection<Uuser> UserViewLList { get; set; }
        public ObservableCollection<Log> LogList { get; set; }
        private static GlobalData _Instance;
        private readonly AppDbContext _dbContext;

        private GlobalData()
        {
            _dbContext = new AppDbContext();
            _dbContext.Database.EnsureCreated(); // Создаем БД, если ее нет

            // Загружаем задачи из базы данных
            var tasks = _dbContext.Tasks.ToList();
            TaskViewList = new ObservableCollection<TaskViewModel>(
                tasks.Select(t => new TaskViewModel(t).Parent == null ? new TaskViewModel(t):null));
            var logs = _dbContext.Logs.ToList();
            LogList = new ObservableCollection<Log>(logs);
            EventBus.onLogChanged += addLog;
            TagViewLList = new ObservableCollection<UTag>
        {
            new UTag(1,"Work","#0078D7"),
            new UTag(2,"Personal","#E81123"),
            new UTag(3,"Urgent","#FF8C00")
        };
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
        public void addLog(string Description)
        {
            Log log = new Log(Description);
            _dbContext.Logs.Add(log);
            _dbContext.SaveChanges();
            LogList.Add(log);
        }

        // Методы для работы с базой данных
        public void AddTask(UTask task)
        {
            _dbContext.Tasks.Add(task);
            
            TaskViewList.Add(new TaskViewModel(task));
        }

        public void UpdateTask(UTask task)
        {
            _dbContext.Tasks.Update(task);
            _dbContext.SaveChanges();
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
            EventBus.onLogChanged?.Invoke($"Удалена задача'{task.DueDate}'");
        }

        internal Task DeleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}