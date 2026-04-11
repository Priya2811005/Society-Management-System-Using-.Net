using System.ComponentModel.DataAnnotations;

namespace Society_Management_System.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required, Phone]
        public string Contact { get; set; }

        [Required]
        public string Flat { get; set; }

        [Required]
        public string Wing { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}