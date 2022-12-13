using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using _24LoginAndReg.Models;


namespace _24LoginAndReg.Controllers;

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
        return View("Index");
    }

    [HttpPost("user/create")]
    public IActionResult CreateUser(User NewUser)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }
        PasswordHasher<User> Hasher = new PasswordHasher<User>();
        NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
        _context.Add(NewUser);
        _context.SaveChanges();
        HttpContext.Session.SetInt32("uuid", NewUser.UserId);
        return RedirectToAction("Success");
    }

    [HttpPost("/process_login")]
    public IActionResult ProcessLogin(Login NewLogin)
    {
        if (ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == NewLogin.EmailLogin);

            if (userInDb == null)
            {
                ModelState.AddModelError("EmailLogin", "Invalid Email/Password");
                return View("Index");
            }

            PasswordHasher<Login> hasher = new PasswordHasher<Login>();

            var result = hasher.VerifyHashedPassword(NewLogin, userInDb.Password, NewLogin.PasswordLogin);

            System.Console.WriteLine(NewLogin.PasswordLogin);

            if (result == 0)
            {
                ModelState.AddModelError("PasswordLogin", "Invalid Email/Password -> Password");
                return View("Index");
            }
            HttpContext.Session.SetInt32("uuid", userInDb.UserId);
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [SessionCheck]
    [HttpGet("/success")]
    public IActionResult Success()
    {
        return View("Success");
    }

}


public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("uuid");
        // Check to see if we got back null
        if(userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}