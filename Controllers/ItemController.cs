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
    public async Task<IEnumerable<ItemDto>> GetItemsAsync()
    {
        return (await _repository.GetItemsAsync()).Select(item => item.ToDto());
    }

    [HttpGet("{itemId:guid}")]
    public async Task<ActionResult<ItemDto>> GetItemAsync(Guid itemId)
    {
        try
        {
            var item = await _repository.GetItemAsync(itemId);
            return item.ToDto();
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
    {
        Item item = new()
        {
            Id = Guid.NewGuid(),
            Name = itemDto.Name,
            Price = itemDto.Price,
            CreatedDate = DateTimeOffset.UtcNow
        };
        await _repository.CreateItemAsync(item);

       
        // ReSharper disable once Mvc.ActionNotResolved
        return CreatedAtAction(nameof(GetItemAsync), new {itemId = item.Id}, item.ToDto());
    }

    [HttpPut("{itemId:guid}")]
    public async Task<ActionResult> UpdateItem(Guid itemId, UpdateItemDto itemDto)
    {
        await _repository.UpdateItemAsync(itemId, new Item
        {
            Id = itemId,
            Name = itemDto.Name,
            CreatedDate = DateTimeOffset.UtcNow,
            Price = itemDto.Price
        });
        return NoContent();
    }

    [HttpDelete("{itemId:guid}")]
    public async Task<ActionResult> DeleteItem(Guid itemId)
    {
        await _repository.DeleteItemAsync(itemId);
        return NoContent();
    }

    
}