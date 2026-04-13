using System;
using System.ComponentModel.DataAnnotations;

namespace Society_Management_System.Models
{
    public class Complaint
    {
        public int ComplaintId { get; set; }

        public int UserId { get; set; }

        [Required]
        public DateTime ComplaintDate { get; set; }

        [Required]
        public string Description { get; set; }

        public string? ImagePath { get; set; }

        public string Status { get; set; }
    }
}