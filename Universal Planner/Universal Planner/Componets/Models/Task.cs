using System;
using System.Collections.Generic;
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


        public int? ParentTaskId { get; set; }


        [ForeignKey("ParentTaskId")]
        public virtual UTask ParentTask { get; set; }


        public virtual ICollection<UTask> SubTasks { get; set; } = new List<UTask>();

        public virtual ICollection<UTaskTag> TaskTags { get; set; }
    = new List<UTaskTag>();

        public UTask()
        {
            Title = "Новая задача";
            Description = "...";
            IsCompleted = false;
            DueDate = DateTime.MinValue;
            CreateDateTime = DateTime.Now;
        }

        public UTask(string title, string description, bool isCompleted)
        {
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            DueDate = DateTime.MinValue;
            CreateDateTime = DateTime.Now;
        }
    }
}