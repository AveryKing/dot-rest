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

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return await Task.FromResult(_items);
    }

    public async Task<Item> GetItemAsync(Guid itemId)
    {
        var item = _items.Single(item => item.Id == itemId);
        return await Task.FromResult(item);
    }

    public async Task CreateItemAsync(Item item)
    {
        _items.Add(item);
        await Task.CompletedTask;
    }

    public async Task UpdateItemAsync(Guid id, Item item)
    {
        var index = _items.FindIndex(x => x.Id == id);
        var updatedItem = _items[index] = item;
        await Task.CompletedTask;
    }

    public async Task DeleteItemAsync(Guid id)
    {
        _items.Remove(await GetItemAsync(id));
    }
}