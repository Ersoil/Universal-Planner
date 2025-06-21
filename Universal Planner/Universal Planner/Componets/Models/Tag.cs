using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Universal_Planner.Componets.Models
{
    [Table("Tags")]
    public class UTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Color { get; set; }

        // Связь многие-ко-многим с задачами
        public virtual ICollection<UTask> Tasks { get; set; } = new List<UTask>();
    }
}