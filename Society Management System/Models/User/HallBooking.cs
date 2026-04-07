using System;

namespace Society_Management_System.Models
{
    public class HallBooking
    {
        public int Id { get; set; }
        public string HallType { get; set; }
        public DateTime BookingDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Purpose { get; set; }
    }
}