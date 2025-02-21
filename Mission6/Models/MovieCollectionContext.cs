using Microsoft.EntityFrameworkCore;

namespace Mission6.Models;

// Database context for the application
public class MovieCollectionContext : DbContext
{
    // Constructor to configure database options
    public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
    {
    }

    // DbSet representing the Movies table
    public DbSet<Movie> Movies { get; set; }

    // DbSet representing the Categories table
    public DbSet<Category> Categories { get; set; }
}