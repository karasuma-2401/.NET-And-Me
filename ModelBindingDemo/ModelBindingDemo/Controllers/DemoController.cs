using Microsoft.AspNetCore.Mvc;
using ModelBindingDemo.Models;

namespace ModelBindingDemo.Controllers;

public class DemoController : Controller
{
    public IActionResult Index(Person person, List<string> strings)
    {
        return Content($"id: {person.Id}, name: {person.Name}, year: {person.Year} strings: {string.Join(", ", strings)} (ModelState: {ModelState.IsValid})");
    }
}