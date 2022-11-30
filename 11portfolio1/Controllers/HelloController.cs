// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace YourNamespace.Controllers;

public class HelloController : Controller   // Remember inheritance?    
{

    [HttpGet("")] // We will go over this in more detail on the next page    
    public string Index()
    {

        return "This is my Index!";
    }

    [HttpGet("/projects")] // We will go over this in more detail on the next page    
    public string projects()
    {

        return "This is my Project Page!";
    }
    
    [HttpGet("/contacts")] // We will go over this in more detail on the next page    
    public string contacts()
    {

        return "This is my Contact Page!";
    }
}