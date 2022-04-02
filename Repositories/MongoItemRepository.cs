using DotRest2.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DotRest2.Repositories;

public class MongoItemRepository : IItemRepository
{
    private const string DatabaseName = "catalog";
    private const string CollectionName = "items";
    private readonly IMongoCollection<Item> _items;
    private readonly FilterDefinitionBuilder<Item> _filterBuilder;
    
    public MongoItemRepository(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(DatabaseName);
        _items = database.GetCollection<Item>(CollectionName);
        _filterBuilder = Builders<Item>.Filter;
    }
    
    public void CreateItem(Item item) => _items.InsertOne(item);
    
    public IEnumerable<Item> GetItems()
    {
        return _items.Find(new BsonDocument()).ToList();
    }

    public Item GetItem(Guid itemId)
    {
        var filter = _filterBuilder.Eq(item => item.Id, itemId);
        return _items.Find(filter).SingleOrDefault();
    }


    

    public void UpdateItem(Guid id, Item item)
    {
        var filter = _filterBuilder.Eq(x => x.Id, id);
        _items.ReplaceOne(filter, item);

    }

    public void DeleteItem(Guid id)
    {
        var filter = _filterBuilder.Eq(item => item.Id, id);
        _items.DeleteOne(filter);
    }
}