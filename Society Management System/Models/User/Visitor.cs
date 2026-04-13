using System;
using System.ComponentModel.DataAnnotations;

namespace Society_Management_System.Models
{
    public class Visitor
    {
        [Key]
        public int VisitorId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string VisitorName { get; set; }

        [Required]
        public string Purpose { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        public string VisitDetails { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}