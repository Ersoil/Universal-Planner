using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Universal_Planner.Componets.Models
{
    [Table("Logs")]
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public DateTime LogDateTime { get; set; }
        public string LogDescription { get; set; } 

        public Log()
        {
            LogDateTime = DateTime.Now;
            LogDescription = "...";
        }

        public Log(string Description)
        {
            LogDateTime = DateTime.Now;
            LogDescription = Description;
        }
    }
}
