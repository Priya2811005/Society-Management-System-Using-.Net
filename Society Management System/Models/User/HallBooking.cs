using System.ComponentModel.DataAnnotations;

namespace Society_Management_System.Models
{
    public class HallBooking
    {
        public int Id { get; set; }

        [Required]
        public string HallType { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public string StartTime { get; set; }

        [Required]
        public string EndTime { get; set; }

        [Required]
        public string Purpose { get; set; }

        public string Status { get; set; } = "Pending";

        public int UserId { get; set; }
        public User User { get; set; }
    }
}