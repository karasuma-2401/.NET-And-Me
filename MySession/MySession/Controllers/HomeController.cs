using MySession.MySession;

namespace MySession.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        var session = HttpContext.GetSession();
        session.SetString("Name", "Thang");
        await session.CommitAsync();
        return View();
    }

    public async Task<IActionResult> Privacy()
    {
        var session = HttpContext.GetSession();
        await session.LoadAsync();
        var name = session.GetString("Name");
        return View("Privacy", name);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}