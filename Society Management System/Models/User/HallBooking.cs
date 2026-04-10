using System;
using System.ComponentModel.DataAnnotations;

namespace Society_Management_System.Models
{
    public class HallBooking
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string HallType { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public string StartTime { get; set; }

        [Required]
        public string EndTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Purpose { get; set; }
    }
}