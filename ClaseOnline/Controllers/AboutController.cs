using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClaseOnline.Models;
using Microsoft.VisualBasic;

namespace ClaseOnline.Controllers;

public class AboutController : Controller
{
    private readonly ILogger<AboutController> _logger;

    public AboutController(ILogger<AboutController> logger)
    {
        _logger = logger;
    }

    public IActionResult About()
    {
        
        int suma = 3*4;
        return View(suma);
    }

    public IActionResult Privacy()
    {
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
