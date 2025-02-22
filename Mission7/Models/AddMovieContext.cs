using Microsoft.EntityFrameworkCore;

namespace Mission7.Models;

public class AddMovieContext : DbContext
{
    public AddMovieContext(DbContextOptions<AddMovieContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ensure CategoryId is properly mapped as a Foreign Key
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Category)
            .WithMany()
            .HasForeignKey(m => m.CategoryId);

        // Map EF models to the existing database tables
        modelBuilder.Entity<Movie>().ToTable("Movies");
        modelBuilder.Entity<Category>().ToTable("Categories");

        // If you want to seed data, it only works if the database is empty
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
            new Category { CategoryId = 2, CategoryName = "Drama" },
            new Category { CategoryId = 3, CategoryName = "Television" },
            new Category { CategoryId = 4, CategoryName = "Horror/Suspense" },
            new Category { CategoryId = 5, CategoryName = "Comedy" },
            new Category { CategoryId = 6, CategoryName = "Family" },
            new Category { CategoryId = 7, CategoryName = "Action/Adventure" },
            new Category { CategoryId = 8, CategoryName = "VHS" }
        );
    }
}