using Entities;
using Usecases;

namespace Infrastructure;

public class InMemoryTodoItemRepository: ITodoItemRepository
{
    private readonly List<TodoItem> _items;

    public InMemoryTodoItemRepository()
    {
        _items = [];
    }

    public void Add(TodoItem item)
    {
        _items.Add(item);
    }

    public void Delete(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            _items.Remove(item);
        }
    }

    public TodoItem? GetById(int id)
    {
        return _items.FirstOrDefault(i => i.Id == id);
    }

    public IEnumerable<TodoItem> GetItems()
    {
        return _items;
    }

    public void Update(TodoItem item)
    {
        var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
        if (existingItem != null)
        {
            existingItem.Description = item.Description;
            existingItem.IsDone = item.IsDone;
        }
    }
}