using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Universal_Planner.Componets.Models
{
    [Table("TaskTags")]
    public class UTaskTag
    {
        // Композитный ключ из двух полей
        [Key, Column(Order = 0)]
        public int TaskId { get; set; }
        [Key, Column(Order = 1)]
        public int TagId { get; set; }

        // Навигационные свойства
        [ForeignKey(nameof(TaskId))]
        public UTask Task { get; set; }

        [ForeignKey(nameof(TagId))]
        public UTag Tag { get; set; }
    }
}