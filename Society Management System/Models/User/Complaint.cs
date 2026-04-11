using System.ComponentModel.DataAnnotations;

namespace Society_Management_System.Models
{
    public class Complaint
    {
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime ComplaintDate { get; set; } = DateTime.Now;

        public string? ImagePath { get; set; }

        public string Status { get; set; } = "Pending";

        public int UserId { get; set; }

        public User? User { get; set; }
    }
}