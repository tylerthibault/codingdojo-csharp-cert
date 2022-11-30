// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace YourNamespace.Controllers;

public class FoodController : Controller   // Remember inheritance?    
{
    [HttpGet("/")] // We will go over this in more detail on the next page    
    public ViewResult Index()
    {
        List<string> FavFoods = new List<string>() {"Pizza", "Ice Cream", "Cinnamon Rolls", "Donuts"};
        ViewBag.Foods = FavFoods;
        return View("Index");
    }
}
