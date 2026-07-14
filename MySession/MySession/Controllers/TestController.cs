using Microsoft.AspNetCore.Mvc;
using MySession.MySession;

namespace MySession.Controllers;

public class TestController : Controller
{
    public IActionResult TestGetSession()
    {
        var session = HttpContext.GetSession();
        session.SetString("Name", "12345678");
        session = HttpContext.GetSession();
        var value = session.GetString("Name");
        if (value == "12345678") return Ok();
        else return BadRequest();
    }

    public async Task<IActionResult> SetSessionValueAsync(string key, string value)
    {
        var session = HttpContext.GetSession();
        await session.LoadAsync();

        session.SetString(key, value);
        await  session.CommitAsync();
        return Ok();
    }

    public async Task<IActionResult> GetSessionValueAsync(string key)
    {
        var session = HttpContext.GetSession();
        await session.LoadAsync();
        var value = session.GetString(key);
        return Ok(value);
    }
}