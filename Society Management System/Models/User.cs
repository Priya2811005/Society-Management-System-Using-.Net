using System.ComponentModel.DataAnnotations;

namespace Society_Management_System.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; } // For demo purposes plain text. Use hashing in production.

        [Required]
        [StringLength(20)]
        public string Role { get; set; } // "Admin" or "User"
    }
}