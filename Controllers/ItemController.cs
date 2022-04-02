using DotRest2.Data;
using DotRest2.Entities;
using DotRest2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotRest2.Controllers;

[ApiController]
[Route("items")]
public class ItemController : ControllerBase
{
    private readonly IItemRepository _repository;

    public ItemController(IItemRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IEnumerable<ItemDto> GetItems()
    {
        return _repository.GetItems().Select(item => item.ToDto());
    }

    [HttpGet("{itemId:guid}")]
    public ActionResult<ItemDto> GetItem(Guid itemId)
    {
        try
        {
            return _repository.GetItem(itemId).ToDto();
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpPost]
    public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
    {
        Item item = new()
        {
            Id = Guid.NewGuid(),
            Name = itemDto.Name,
            Price = itemDto.Price,
            CreatedDate = DateTimeOffset.UtcNow
        };
        _repository.CreateItem(item);

        return CreatedAtAction(nameof(GetItem), new {itemId = item.Id}, item.ToDto());
    }

    [HttpPut("{itemId:guid}")]
    public object UpdateItem(Guid itemId, UpdateItemDto itemDto)
    {
        _repository.UpdateItem(itemId, new Item
        {
            Id = itemId,
            Name = itemDto.Name,
            CreatedDate = DateTimeOffset.UtcNow,
            Price = itemDto.Price
        });
       return new { message = "success" };

    }

}