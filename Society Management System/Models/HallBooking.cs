using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Society_Management_System.Models
{
    public class HallBooking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        [MaxLength(100)]
        public string HallType { get; set; }

        [Required]
        [Column("BookingDate")]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public string Purpose { get; set; }

        public int UserId { get; set; } = 1;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}