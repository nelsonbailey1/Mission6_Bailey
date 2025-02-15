using Microsoft.EntityFrameworkCore;

namespace Mission6.Models;

public class AddMovieContext : DbContext
{
    public AddMovieContext(DbContextOptions<AddMovieContext> options) : base(options)
    {
        
    }
    
    public DbSet<Application> Movies { get; set; }
}