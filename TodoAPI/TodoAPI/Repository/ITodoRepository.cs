using TodoAPI.Models;

namespace TodoAPI.Repository;

public interface ITodoRepository
{
    Task<IEnumerable<TodoItem>> GetTodoItemsAsync();
    Task<TodoItem?> GetTodoItemAsync(Guid id);
    Task<TodoItem> CreateTodoItemAsync(TodoItem todoItem);
}