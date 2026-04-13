using System;
using System.ComponentModel.DataAnnotations;

namespace Society_Management_System.Models
{
    public class HallBooking
    {
        [Key]
        public int BookingId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string HallType { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public string Purpose { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}