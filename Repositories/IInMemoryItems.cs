using DotRest2.Entities;

namespace DotRest2.Repositories;

public interface IInMemoryItems
{
    IEnumerable<Item> GetItems();
    Item GetItem(Guid itemId);
}