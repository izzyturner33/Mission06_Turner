namespace Mission6.Models;
using System.ComponentModel.DataAnnotations;


public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

    // Navigation property for one-to-many relationship
    public List<Movie> Movies { get; set; }
}