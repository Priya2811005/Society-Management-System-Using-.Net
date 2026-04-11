using System.ComponentModel.DataAnnotations;

namespace Society_Management_System.Models
{
    public class Notice
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int? CreatedBy { get; set; }
        public User Creator { get; set; }
    }
}