namespace TodoList.Models;

public class TodoItem
{
    public int Id  { get; set; }
    public required string Description { get; set; }
    public bool IsDone { get; set; }
}