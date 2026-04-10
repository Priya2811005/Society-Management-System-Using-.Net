using System;
using System.ComponentModel.DataAnnotations;

namespace Society_Management_System.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Subject is required")]
        [StringLength(200, ErrorMessage = "Subject cannot exceed 200 characters")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}