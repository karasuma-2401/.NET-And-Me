using Microsoft.AspNetCore.Mvc;

namespace Lecture3.Controllers;

public class CollectionController : Controller
{
    // GET
    public IActionResult Index(string id)
    {
        return View((object)id);
    }
}  