using DotRest2.Data;
using DotRest2.Entities;

namespace DotRest2;

public static class Extensions
{
    public static ItemDto ToDto(this Item item)
    {
        return new ItemDto
        {
            Id = item.Id,
            Name = item.Name,
            Price = item.Price,
            CreatedDate = item.CreatedDate
        };
    }
}