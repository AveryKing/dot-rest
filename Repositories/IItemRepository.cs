using DotRest2.Entities;

namespace DotRest2.Repositories;

public interface IItemRepository
{
    IEnumerable<Item> GetItems();
    Item GetItem(Guid itemId);
    void CreateItem(Item item);
    void UpdateItem(Guid id, Item item);
    void DeleteItem(Guid id);
}