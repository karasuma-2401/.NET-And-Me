using Ghtk.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ghtk.Api.Controllers;

[ApiController]
[Route("/services/shipment")]
public class ShipmentServiceController : Controller
{
    [Route("order")]
    [HttpPost]
    [Authorize]
    public IActionResult CreateOrder([FromBody] CreateOrder shipment)
    {
        return Ok();
    }
}