using System.ComponentModel.DataAnnotations.Schema;

namespace Firdous_Portfolio.Models
{
    [Table("Projects")]
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Technologies { get; set; }
        public string GitHubUrl { get; set; }
        public string LiveDemoUrl { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
