using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtDemo.Controllers;

public class ApiController : Controller
{
    // GET
    [Authorize]
    public IActionResult SayHello(string name)
    {
        return Content("Hello " + name);
    }
}