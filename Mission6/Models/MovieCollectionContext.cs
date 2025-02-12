using Microsoft.EntityFrameworkCore;

namespace Mission6.Models;

public class MovieCollectionContext :DbContext
{
    public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
    {
        
    }
    
    public DbSet<Form> Movies { get; set; }
}