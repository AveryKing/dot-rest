using DotRest2.Entities;
using MongoDB.Driver;

namespace DotRest2.Repositories;

public class MongoItemRepository : IItemRepository
{
    private const string DatabaseName = "catalog";
    private const string CollectionName = "items";
    private readonly IMongoCollection<Item> _items;
    
    public MongoItemRepository(IMongoClient mongoClient)
    {
        IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
        _items = database.GetCollection<Item>(CollectionName);
    }
    
    public IEnumerable<Item> GetItems()
    {
        throw new NotImplementedException();
    }

    public Item GetItem(Guid itemId)
    {
        throw new NotImplementedException();
    }

    public void CreateItem(Item item)
    {
        _items.InsertOne(item);
    }

    public void UpdateItem(Guid id, Item item)
    {
        throw new NotImplementedException();
    }

    public void DeleteItem(Guid id)
    {
        throw new NotImplementedException();
    }
}