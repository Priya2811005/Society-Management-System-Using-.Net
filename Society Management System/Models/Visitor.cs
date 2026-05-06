using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Society_Management_System.Models
{
    public class Visitor
    {
        [Key]
        public int VisitorId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("Name")]
        public string VisitorName { get; set; }

        [Required]
        [StringLength(200)]
        public string Purpose { get; set; }

        [Required]
        [StringLength(15)]
        public string ContactNumber { get; set; }

        [Required]
        public string VisitDetails { get; set; }

        [Required]
        [Column("VisitDate")]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
