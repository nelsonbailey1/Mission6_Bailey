using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission7.Models;

public class Movie
{
    
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    public int? CategoryId { get; set; }
    
    public Category? Category { get; set; }
    
    [Required(ErrorMessage = "You must enter a Title")] 
    public string Title { get; set; }
    
    [Required(ErrorMessage = "You must enter a valid Year")]
    [Range(1888,2025)]
    public int Year { get; set; }
    
    public string? Director { get; set; }
    
    public string? Rating { get; set; }
    
    [Required(ErrorMessage = "You determine Edited state")]
    public bool Edited { get; set; }
    
    public string? LentTo { get; set; }
    
    [Required(ErrorMessage = "You must determine Copied To Plex state")]
    public bool CopiedToPlex { get; set; }
    public string? Notes { get; set; }
}