using Entities;

namespace Usecases;

public interface ITodoItemRepository
{
    void Add(TodoItem item);
    void Delete(int id);
    TodoItem? GetById(int id);
    IEnumerable<TodoItem> GetItems();
    void Update(TodoItem item);
}