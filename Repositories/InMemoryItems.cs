using DotRest2.Entities;

namespace DotRest2.Repositories;

public interface IInMemoryItems
{
    IEnumerable<Item> GetItems();
    Item GetItem(Guid itemId);
}

public class InMemoryItems : IInMemoryItems
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
}