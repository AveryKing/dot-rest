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

    public async Task CreateItemAsync(Item item)
    {
        await _items.InsertOneAsync(item);
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return await _items.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<Item> GetItemAsync(Guid itemId)
    {
        var filter = _filterBuilder.Eq(item => item.Id, itemId);
        return await _items.Find(filter).SingleOrDefaultAsync();
    }


    public async Task UpdateItemAsync(Guid id, Item item)
    {
        var filter = _filterBuilder.Eq(x => x.Id, id);
        await _items.ReplaceOneAsync(filter, item);
    }

    public async Task DeleteItemAsync(Guid id)
    {
        var filter = _filterBuilder.Eq(item => item.Id, id);
        await _items.DeleteOneAsync(filter);
    }
}