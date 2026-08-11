using Microsoft.AspNetCore.Mvc;

namespace ResourceSharingWeb.Controllers;

public class ApiController : Controller
{
    // GET
    public IActionResult Resource()
    {
        return Content("CORS World Today is 11/8");
    }
}