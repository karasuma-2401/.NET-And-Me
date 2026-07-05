using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoItem = TodoList.Models.TodoItem;

namespace TodoList.Controllers;

public class HomeController : Controller
{
    private readonly TodoListManager _listManager;
    private readonly ILogger<HomeController> _logger;

    public HomeController(TodoListManager listManager, ILogger<HomeController> logger)
    {
        _listManager = listManager;
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        var todoItems = _listManager.GetTodoItems();
        
        return View(new TodoListViewModel()
        {
            TodoItems = todoItems.Select(item => new TodoItem()
            {
                Id = item.Id,
                Description = item.Description,
                IsDone = item.IsDone
            })
        });
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View("Add");
    }

    [HttpPost]
    public IActionResult Add(TodoItem item)
    {
        _listManager.AddTodoItem(new Entities.TodoItem()
        {
            Id = item.Id,
            Description = item.Description,
            IsDone = false,
        });
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}