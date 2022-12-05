using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _17DojoSurveyWithModels.Models;

namespace _17DojoSurveyWithModels.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static User UserInfo = new User();


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("/form/process")]
    public IActionResult FormProcess(User user)
    {
        User NewUser = new User()
        {
            Name = user.Name,
            Loc = user.Loc,
            Lang = user.Lang,
            Comment = user.Comment
        };
        UserInfo = NewUser;
        return RedirectToAction("Result");
    }

    [HttpGet("/result")]
    public IActionResult Result()
    {
        return View("Result", UserInfo);
    }
}
