using System.Diagnostics;
using HttpContext.Helper;
using Microsoft.AspNetCore.Mvc;
using HttpContext.Models;

namespace HttpContext.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        _logger.LogInformation("ID: {id} from {host}", HttpContext.TraceIdentifier, Request.GetDebugInfo());
        return View();
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}