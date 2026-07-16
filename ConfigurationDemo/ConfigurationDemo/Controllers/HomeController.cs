using System.Diagnostics;
using System.Text;
using ConfigurationDemo.ConfigModels;
using Microsoft.AspNetCore.Mvc;
using ConfigurationDemo.Models;
using Microsoft.Extensions.Options;

namespace ConfigurationDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfigurationRoot _configuration;
    private readonly ApiSettings _apiSettings;

    public HomeController(IOptions<ApiSettings> apiSettings,IConfiguration configuration, ILogger<HomeController> logger)
    {
        _apiSettings = apiSettings.Value;
        _configuration = (IConfigurationRoot)configuration;
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    [Route("/providers")]  
    public IActionResult Provider()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Configuration Provider");
        foreach (var provider in _configuration.Providers) 
        {
            sb.AppendLine(provider.ToString());
        }

        sb.AppendLine();
        sb.AppendLine("Configuration Values:");
        foreach (var section in _configuration.GetChildren())
        {
            sb.AppendLine($"[{section.Key}]");
            foreach (var property in section.GetChildren()) 
            {
                sb.AppendLine($"{property.Key} = {property.Value}");
            }
        }
        
        return Content(sb.ToString(),  "text/plain", Encoding.UTF8);
    }
    [Route("/apiSettings")]
    public IActionResult Key([FromRoute]string key)
    {
        // var apiSettings = new ApiSettings();
        // _configuration.GetSection("ApiSettings").Bind(apiSettings);
        return Json(_apiSettings);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}