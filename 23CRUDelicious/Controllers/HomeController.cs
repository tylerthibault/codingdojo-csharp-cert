using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _23CRUDelicious.Models;

namespace _23CRUDelicious.Controllers;

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
        ViewBag.AllDishes = _context.Dishes.ToList();
        return View();
    }

    [HttpGet("/dish/new")]
    public IActionResult DishAdd()
    {
        return View();
    }

    [HttpPost("/dish/create")]
    public IActionResult DishCreate(Dish NewDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(NewDish);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    [HttpGet("/dish/{DishId}/edit")]
    public IActionResult DishEdit(int DishId)
    {
        Dish? CurrentDish = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
        return View("DishEdit", CurrentDish);
    }

    [HttpPost("/dish/{DishId}/update")]
    public IActionResult DishUpdate(Dish NewDish, int DishId)
    {
        if (ModelState.IsValid)
        {
            Dish? OldDish = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
            OldDish.Name = NewDish.Name;
            OldDish.Chef = NewDish.Chef;
            OldDish.Calories = NewDish.Calories;
            OldDish.Tastiness = NewDish.Tastiness;
            OldDish.Description = NewDish.Description;
            OldDish.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else 
        {
            return DishEdit(DishId);
        }

    }

    [HttpGet("/dish/{DishId}/destroy")]
    public IActionResult DishDestroy(int DishId)
    {
        Dish? DishToDestroy = _context.Dishes.SingleOrDefault(d => d.DishId == DishId);
        _context.Dishes.Remove(DishToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
