using DotRest2.Entities;
using Microsoft.AspNetCore.Http.Features;

namespace DotRest2.Repositories;

public class MemoryItemRepository : IItemRepository
{
    private readonly List<Item> _items = new()
    {
        new Item {Id = Guid.NewGuid(), Name = "Computer", Price = 1000, CreatedDate = DateTimeOffset.UtcNow},
        new Item {Id = Guid.NewGuid(), Name = "Phone", Price = 800, CreatedDate = DateTimeOffset.UtcNow},
        new Item {Id = Guid.NewGuid(), Name = "Car", Price = 25000, CreatedDate = DateTimeOffset.UtcNow},
    };

    public IEnumerable<Item> GetItems()
    {
        return _items;
    }

    public Item GetItem(Guid itemId)
    {
        return _items.Single(item => item.Id == itemId);
    }

    public void CreateItem(Item item)
    {
        _items.Add(item);
    }
    
    public void UpdateItem(Guid id, Item item)
    {
        _items[_items.FindIndex(x => x.Id == id)] = item;
    }

    public void DeleteItem(Guid id)
    {
        _items.Remove(GetItem(id));
    }
}