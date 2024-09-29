using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ConcertApp.Models;

namespace ConcertApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Manager _manager;

    // Inject ILogger and ApplicationDbContext, and initialize Manager
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _manager = new Manager(context);  // Pass ApplicationDbContext to the Manager
    }

    // Modify the Index action to pass concert data to the view
    public IActionResult Index()
    {
        var concerts = _manager.GetAll();  // Fetch concerts from the Manager
        return View(concerts);  // Pass the concerts list to the view
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
