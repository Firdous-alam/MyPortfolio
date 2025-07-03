using System.ComponentModel.DataAnnotations.Schema;

namespace Firdous_Portfolio.Models
{
    [Table("Education")]
    public class Education
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        public string Institution { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Grade { get; set; }
    }
}
