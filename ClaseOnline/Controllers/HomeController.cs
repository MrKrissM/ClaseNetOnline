using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClaseOnline.Models;
using Microsoft.VisualBasic;

namespace ClaseOnline.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var autos = new List<string>
        {
            "renault",
            "mazda",
            "subaru",
            "fiat"
        };
        
        var frutas = new List<string>
        {
            "naranja",
            "platano",
            "cereza"
        };

           var nombres = new List<string>
        {
            "jorge",
            "carlos",
            "maria",
            "samuel"
        };
        ViewData["Autos"] = autos;
        ViewBag.frutas = frutas;
        TempData["Nombres"] = nombres;

        return View();
    }
       

    public IActionResult Privacy()
    {
        List<string> nombres = TempData["Nombres"] as List<string>;
        if(nombres.Count > 0){
            ViewData["Nombres"] = nombres;
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
