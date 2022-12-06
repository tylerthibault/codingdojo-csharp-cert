using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _21SessionWorkshop.Models;

namespace _21SessionWorkshop.Controllers;

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

    [HttpPost("/login")]
    public IActionResult Login(Person NewPerson)
    {
        if (ModelState.IsValid)
        {   
            HttpContext.Session.SetInt32("Number", 22);
            HttpContext.Session.SetString("UserName", NewPerson.Name);
            return RedirectToAction("Game");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpPost("/numberhandler")]
    public IActionResult NumberHandler(string Type)
    {
        int number = (int)HttpContext.Session.GetInt32("Number");
        if (Type == "plusOne")
        {
            number = number + 1;
        }
        else if (Type == "minusOne")
        {
            number = number - 1;
        }
        else if (Type == "timesTwo")
        {
            number = number * 2;
        }
        else if (Type == "random")
        {
            Random rand = new Random();
            int randNum = rand.Next(1,10);
            number += randNum;
        }
        else {
            System.Console.WriteLine("You have done something interesting.");
        }

        HttpContext.Session.SetInt32("Number", number);
        return RedirectToAction("Game");
    }

    [HttpGet("/game")]
    public IActionResult Game()
    {
        return View();
    }

    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
