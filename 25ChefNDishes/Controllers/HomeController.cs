using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _25ChefNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace _25ChefNDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return RedirectToAction("Chefs");
    }

    // Chefs Routes

    [HttpGet("/chefs")]
    public IActionResult Chefs()
    {
        List<Chef> AllChefs = _context.Chefs.Include(c => c.CreatedDishes).ToList();
        return View("ChefsShow", AllChefs);
    }

    [HttpGet("/chef/new")]
    public IActionResult ChefsNew()
    {
        return View("ChefsNew");
    }

    [HttpPost("/chef/create")]
    public IActionResult ChefCreate(Chef NewChef)
    {
        if (!ModelState.IsValid)
        {
            return View("ChefsNew");
        }

        _context.Add(NewChef);
        _context.SaveChanges();
        System.Console.WriteLine("created and saved");

        return RedirectToAction("Index");
    }

    // Dishes Routes

    [HttpGet("/dishes")]
    public IActionResult Dishes()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllDishes = _context.Dishes.Include(c => c.Chef).ToList()
        };
        return View("DishesShow", MyModel);
    }

    [HttpGet("/dish/new")]
    public IActionResult DishesNew()
    {
        MyViewModel MyModels = new MyViewModel
        {
            AllChefs = _context.Chefs.ToList(),
            Dish = new Dish(),
        };
        return View("DishesNew", MyModels);
    }

    [HttpPost("/dish/create")]
    public IActionResult DishCreate(Dish dish)
    {
        if (!ModelState.IsValid)
        {
            return DishesNew();
        }

        _context.Add(dish);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
