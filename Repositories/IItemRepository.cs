using DotRest2.Entities;

namespace DotRest2.Repositories;

public interface IItemRepository
{
    IEnumerable<Item> GetItems();
    Item GetItem(Guid itemId);
}