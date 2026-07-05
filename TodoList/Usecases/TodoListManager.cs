using Entities;

namespace Usecases;

public class TodoListManager (ITodoItemRepository repository)
{
    private readonly ITodoItemRepository _repository = repository;

    public IEnumerable<TodoItem> GetTodoItems()
    {
        return _repository.GetItems();
    }

    public void AddTodoItem(TodoItem item)
    {
        _repository.Add(item);
    }

    public void DeleteTodoITem(int id)
    {
        _repository.Delete(id);
    }

    public void MarkDone(int id)
    {
        var item = repository.GetById(id);
        if (item != null)
        {
            item.IsDone = true;
            _repository.Update(item);
        }
    }
}