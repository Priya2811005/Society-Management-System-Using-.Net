using System;

namespace Society_Management_System.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}