using System.ComponentModel.DataAnnotations;

namespace Society_Management_System.Models
{
    public class Visitor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required, Phone]
        public string Contact { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        public string Purpose { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}