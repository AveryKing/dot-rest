using DotRest2.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DotRest2.Repositories;

public class MongoItemRepository : IItemRepository
{
    private const string DatabaseName = "catalog";
    private const string CollectionName = "items";
    private readonly IMongoCollection<Item> _items;
    
    public MongoItemRepository(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(DatabaseName);
        _items = database.GetCollection<Item>(CollectionName);
    }
    
    public void CreateItem(Item item) => _items.InsertOne(item);
    
    public IEnumerable<Item> GetItems()
    {
        return _items.Find(new BsonDocument()).ToList();
    }

    public Item GetItem(Guid itemId)
    {
        throw new NotImplementedException();
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