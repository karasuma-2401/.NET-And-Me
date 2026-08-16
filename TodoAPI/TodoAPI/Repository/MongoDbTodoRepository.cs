using MongoDB.Driver;
using TodoAPI.Models;

namespace TodoAPI.Repository;

public class MongoDbTodoRepository: ITodoRepository
{
    private readonly IMongoCollection<TodoItem> _collection;

    public MongoDbTodoRepository(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("TodoDb"));
        var database = client.GetDatabase(configuration["TodoApiDatabaseName"]);
        this._collection = database.GetCollection<TodoItem>("TodoItems");
    }

    public MongoDbTodoRepository(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        this._collection = database.GetCollection<TodoItem>("TodoItems");
    }
    
    
    public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<TodoItem?> GetTodoItemAsync(Guid id)
    {
        return await _collection.Find(item => item.Id == id).FirstOrDefaultAsync();
    }

    public async Task<TodoItem> CreateTodoItemAsync(TodoItem todoItem)
    {
        await _collection.InsertOneAsync(todoItem);
        return todoItem;
    }
}