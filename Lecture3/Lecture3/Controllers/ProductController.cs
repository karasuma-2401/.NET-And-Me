using Lecture3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lecture3.Controllers;

public class ProductController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    [Route("/product/{id:int}")]
    public IActionResult Details(int id)
    {
        return View(new Product()
        {
            Id = id.ToString(),
            Name = $"Product Name: {id} (int)"
        });
    }
    [Route("/product/{name}")]
    public IActionResult Details(string name)
    {
        return View(new Product()
        {
            Id = name,
            Name = $"Product Name: {name} (string)"
        });
    }
}