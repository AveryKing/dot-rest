using System.ComponentModel.DataAnnotations;

namespace DotRest2.Data;

public record UpdateItemDto
{
    [Required]
    public string? Name { get; init; } 
    [Required]
    [Range(1,1000)]
    public decimal Price { get; init; }
}