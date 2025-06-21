using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Universal_Planner.Componets.Models
{
    [Table("Tasks")]
    public class UTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime DueDate { get; set; }

        public UTask()
        {
            Title = "Новая задача";
            Description = "...";
            IsCompleted = false;
            DueDate = DateTime.MinValue;
        }

        public UTask(string title, string description, bool isCompleted)
        {
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            DueDate = DateTime.MinValue;
        }
    }
}