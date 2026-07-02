using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lecture2.Models;

namespace Lecture2.Controllers;


// [NonController] // can be inheritance
public class HomeController : Controller
{
    private readonly  ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    // [NonAction]  mark is not a action method
    public IActionResult Contact()
    {
        return View();
    }

    [HttpGet]
    [Route("/api/users")]
    public IActionResult Users([FromHeader] string token, [FromServices] IUserRepository userRepository)
    {
        _logger.LogInformation("[Users] METHOD: {m}, token = {token}", Request.Method, token);
        ValidateToken(token);
        return Content($"Users: {string.Join(',', userRepository.Users)}");
    }

    [HttpPost]
    [Route("/api/users")]
    public IActionResult Users([FromHeader] string token, [FromServices]IUserRepository userRepository, string user)
    {
        userRepository.Add(user);
        ValidateToken(token);
        return Ok();
    }
    private void ValidateToken(string token) 
    {
        if (token == null)
        {
            throw new ArgumentNullException(nameof(token));
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}