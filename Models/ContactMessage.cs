﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Firdous_Portfolio.Models
{
    [Table("ContactMessages")]
    public class ContactMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
    }
}
