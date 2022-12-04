// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;

// Be sure to use your own project's namespace here! 
namespace dojoSurvey.Controllers;   

public class HomeController : Controller   // Remember inheritance?    
{      
    [HttpGet("")] // We will go over this in more detail on the next page    
    public ViewResult Index()        
    {            
         return View();       
    }    

    [HttpPost("/formProcess")]
    public IActionResult Process(string name="", string loc="", string lang="", string comments="")
    {
        HttpContext.Session.SetString("name", name); 
        HttpContext.Session.SetString("loc", loc); 
        HttpContext.Session.SetString("lang", lang); 
        HttpContext.Session.SetString("comments", comments); 
        
        return RedirectToAction("Results");
    }

    [HttpGet("/results")]
    public ViewResult Results()
    {

        return View();
    }
}