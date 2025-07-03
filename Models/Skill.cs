using System.ComponentModel.DataAnnotations.Schema;

namespace Firdous_Portfolio.Models
{
    [Table("Skills")]
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Proficiency { get; set; }
        public string Category { get; set; }
    }
}
