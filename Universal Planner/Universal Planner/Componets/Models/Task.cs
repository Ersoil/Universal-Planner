using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Planner.Componets.Models
{
    class UTask
    {
        public string Title { get; set; }         
        public string Description { get; set; }   
        public bool IsCompleted { get; set; }      
        public DateTime DueDate { get; set; }
        private int ID;

        public UTask()
        {
            Title = "Undefined";
            Description = "Undefined";
            IsCompleted = false;
            DueDate = DateTime.MinValue;
        }
    }
}
