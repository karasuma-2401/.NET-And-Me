using Microsoft.AspNetCore.Mvc;

namespace SessionDemo.Controllers;

public class SessionController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SetSession(string key, string value)
    {
        HttpContext.Session.SetString(key, value);
        return Ok($"Session[{key}]: {value}");
    }

    public IActionResult GetSession(string key)
    {
        return Ok(HttpContext.Session.GetString(key) ?? "No Content");
    }
}