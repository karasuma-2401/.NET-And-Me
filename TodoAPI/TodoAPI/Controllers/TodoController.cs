using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;
using TodoAPI.Repository;

namespace TodoAPI.Controllers;

public class TodoController : ControllerBase
{
    private readonly ITodoRepository _todoRepository;
    public TodoController(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetTodoItems()
    {
        return Ok(await _todoRepository.GetTodoItemsAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoItemAsync(Guid id)
    {
        var item = await _todoRepository.GetTodoItemAsync(id);
        if (item == null)
            return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodoItem(TodoItem todoItem)
    {
        return Ok(await _todoRepository.CreateTodoItemAsync(todoItem));
    }
    
    
    [HttpPut("{id}")]
    public IActionResult UpdateTodoItem(int id)
    {
        return Ok($"UpdateTodoItem {id}");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTodoItem(int id)
    {
        return Ok($"DeleteTodoItem {id}");
    }
}