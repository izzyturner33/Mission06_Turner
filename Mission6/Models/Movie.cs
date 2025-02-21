using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models;

// Represents a movie entity
public class Movie
{
    // Primary key
    [Key]
    [Required]
    public int MovieId { get; set;  }
    
    // Title is required
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    
    // Foreign key reference to Category
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    
    // Navigation property for Category
    public Category? Categories { get; set; }
    
    // Release year must be between 1888 and 2025
    [Required(ErrorMessage = "Release year is required")]
    [Range(1888, 2025, ErrorMessage = "Year must be between 1888 and 2025.")]
    public int Year { get; set; }

    // Optional fields
    public string? Director { get; set; }
    public string? Rating { get; set; }
    
    // Indicates if the movie is edited (1 = Yes, 0 = No)
    [Required(ErrorMessage = "Edited is required")]
    public int Edited { get; set; }
    
    // Who the movie was lent to, if applicable
    public string? LentTo { get; set; }
    
    // Indicates if the movie was copied to Plex (1 = Yes, 0 = No)
    [Required(ErrorMessage = "Copied to Plex is required")]
    public int CopiedToPlex { get; set; }
    
    // Additional notes about the movie
    public string? Notes { get; set; }
}