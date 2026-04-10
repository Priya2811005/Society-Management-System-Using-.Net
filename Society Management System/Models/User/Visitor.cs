using System;
using System.ComponentModel.DataAnnotations;

namespace Society_Management_System.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Valid contact number required")]
        public string Contact { get; set; }
        public DateTime VisitDate { get; set; }
        public string Purpose { get; set; }
    }
}