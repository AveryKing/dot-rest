using DotRest2.Entities;
using DotRest2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotRest2.Controllers;

[ApiController]
[Route("items")]
public class ItemController : ControllerBase
{
    private readonly InMemoryItems _repository;

    public ItemController()
    {
        _repository = new InMemoryItems(); 
    }

    [HttpGet]
    public IEnumerable<Item> GetItems()
    {
        return _repository.GetItems();
    }
}