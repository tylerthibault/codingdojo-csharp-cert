using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _20formSubmission.Models;

namespace _20formSubmission.Controllers;

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

    [HttpPost("/formchecker")]
    public IActionResult FormChecker(Form NewForm)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Success");
        }
        else 
        {
            return View("Index");
        }
    }

    [HttpGet("/success")]
    public IActionResult Success()
    {
        return View();
    }
}
