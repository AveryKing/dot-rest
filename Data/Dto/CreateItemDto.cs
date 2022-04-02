namespace DotRest2.Data;

public record CreateItemDto
{
    public string? Name { get; init; } 
    
    public decimal Price { get; init; }
}