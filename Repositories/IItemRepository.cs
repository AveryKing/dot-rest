using DotRest2.Entities;

namespace DotRest2.Repositories;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetItemsAsync();
    Task<Item> GetItemAsync(Guid itemId);
    Task CreateItemAsync(Item item);
    Task UpdateItemAsync(Guid id, Item item);
    Task DeleteItemAsync(Guid id);
}