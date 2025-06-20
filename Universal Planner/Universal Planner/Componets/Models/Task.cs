using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Planner.Componets.Models
{
    public class UTask
    {
        public string Title { get; set; }         
        public string Description { get; set; }   
        public bool IsCompleted { get; set; }      
        public DateTime DueDate { get; set; }
        private int ID;

        public UTask()
        {
            Title = "Task Title";
            Description = "Task Description";
            IsCompleted = false;
            DueDate = DateTime.MinValue;
        }

        public UTask(string Title, string Description,bool isCompleted)
        {
            this.Title = Title;
            this.Description = Description;
            IsCompleted = isCompleted;
            DueDate = DateTime.MinValue;
        }
    }
}
