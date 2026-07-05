namespace TodoList.Models;

public class TodoListViewModel
{
    public required IEnumerable<TodoItem> TodoItems { get; init; }
}