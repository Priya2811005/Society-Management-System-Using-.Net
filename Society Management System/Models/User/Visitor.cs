using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Visitor
{
    [Key]
    public int VisitorId { get; set; }

    [NotMapped]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Visitor Name is required")]
    public string VisitorName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Purpose is required")]
    public string Purpose { get; set; } = string.Empty;

    [Required(ErrorMessage = "Contact Number is required")]
    public string ContactNumber { get; set; } = string.Empty;

    public string? VisitDetails { get; set; }

    public DateTime RequestDate { get; set; } = DateTime.Now;
}