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
        return _repository.GetItems().Select(item => new ItemDto
        {
            Id = item.Id,
            Name = item.Name,
            Price = item.Price,
            CreatedDate = item.CreatedDate
        });
    }

    [HttpGet("{itemId:guid}")]
    public ActionResult<Item> GetItem(Guid itemId)
    {
        try
        {
            var item = _repository.GetItem(itemId);
            return item;
        }
        catch
        {
            return NotFound();
        }
    }
}