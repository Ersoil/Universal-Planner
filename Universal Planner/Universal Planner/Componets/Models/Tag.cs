using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

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

        // Навигация many-to-many
        public virtual ICollection<UTaskTag> TaskTags { get; set; }
            = new List<UTaskTag>();

        public UTag() { }
        public UTag(int id, string name, string color)
        {
            Id = id; Name = name; Color = color;
        }
    }
}