using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtDemo.Controllers;

[Authorize]
public class ApiController : Controller
{
    public IActionResult SayHello(string name)
    {
        return Content("Hello " + name);
    }
    [Authorize(Roles = "Role1")]
    public IActionResult SayHello1(string name)
    {
        return Content("Hello " + name);
    }
    [Authorize(Roles = "Role2")]
    public IActionResult SayHello2(string name)
    {
        return Content("Hello " + name);
    }
    [Authorize(Roles = "Role3")]
    public IActionResult SayHello3(string name)
    {
        return Content("Hello " + name);
    }
    [AllowAnonymous]
    public IActionResult HelloAnonymous(string name)
    {
        return Content("Hello " + name);
    }
}