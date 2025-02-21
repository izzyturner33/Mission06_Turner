using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models;

// make the first fields required and the last three not required
public class Movies
{
    [Key]
    [Required]
    public int MovieId { get; set;  }
    
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    
    
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    
    [Required(ErrorMessage = "Category is required")]
    public Categories Categories { get; set; }
    
    [Required(ErrorMessage = "Release year is required")]
    [Range(1888, 2025)]
    public int Year { get; set; }
    
    [Required(ErrorMessage = "Director is required")]
    public string Director { get; set; }
    
    [Required(ErrorMessage = "Rating is required")]
    public string Rating { get; set; }
    
    public int? Edited { get; set; }
    
    public string? LentTo { get; set; }
    
    [MaxLength(25)] // make the length max 25
    public int CopiedToPlex { get; set; }
    
    public string? Notes { get; set; }
    
}