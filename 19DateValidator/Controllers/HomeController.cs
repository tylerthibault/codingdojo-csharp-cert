using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _19DateValidator.Models;

namespace _19DateValidator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("/datechecker")]
    public IActionResult Checker(DateTime CheckDate)
    {
        bool IsValid = Date.Checker(CheckDate);
        System.Console.WriteLine(IsValid);
        return RedirectToAction("Index");
    }

}
