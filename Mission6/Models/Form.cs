using System.ComponentModel.DataAnnotations;

namespace Mission6.Models;

// make the first fields required and the last three not required
public class Form
{
    [Key]
    [Required]
    public int FormId { get; set;  }
    [Required]
    public string MovieTitle { get; set; }
    [Required]
    public string MovieCategory { get; set; }
    [Required]
    public string ReleaseYear { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string Rating { get; set; }
    public string? Edited { get; set; }
    public string? LentTo { get; set; }
    [MaxLength(25)] // make the length max 25
    public string? Notes { get; set; }
    
}