using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _16ViewModelFun.Models;

namespace _16ViewModelFun.Controllers;

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

    [HttpGet("/numbers")]
    public IActionResult NumberRoute()
    {
        List<int> MyNumbers = new List<int>() {1,4,2,6,8,4,12,65};

        return View(MyNumbers);
    }

    [HttpGet("/user")]
    public IActionResult UserRoute()
    {
        User MyUser = new User(){
            FirstName = "Tyler",
            LastName = "Tbo"
        };
        return View(MyUser);
    }

    [HttpGet("/users")]
    public IActionResult UsersRoute()
    {
        List<User> AllUsers = new List<User>();
        User Tyler = new User(){FirstName = "Tyler", LastName = "Tbo"};
        User Joe = new User(){FirstName = "Joe", LastName = "Tbo"};
        User Curtis = new User(){FirstName = "Curtis", LastName = "Tbo"};

        AllUsers.Add(Tyler);
        AllUsers.Add(Joe);
        AllUsers.Add(Curtis);
        return View(AllUsers);
    }
}
