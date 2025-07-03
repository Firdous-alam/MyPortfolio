﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Firdous_Portfolio.Models
{
    [Table("Experience")]
    public class Experience
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrent { get; set; }
    }
}
