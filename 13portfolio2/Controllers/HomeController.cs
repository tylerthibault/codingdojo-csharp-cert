// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
namespace Porfolio2.Controllers;

public class HomeController : Controller   // Remember inheritance?    
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }
    
    [HttpGet("/projects")]
    public ViewResult Projects()
    {
        return View();
    }
    
    [HttpGet("/contacts")]
    public ViewResult Contacts()
    {
        return View();
    }
}