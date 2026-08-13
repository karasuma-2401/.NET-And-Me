using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace RateLimitingDemo.Controllers;

public class ApiController : Controller
{
    [Route("/api/v1/time")]
    [HttpGet]
    [EnableRateLimiting("FixedWindowLimiter")]
    public IActionResult CurrentTime()
    {
        var currentTime = DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss");
        return Ok(currentTime);
    }
}