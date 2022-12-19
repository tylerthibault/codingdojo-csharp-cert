using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using _27WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace _27WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // [SessionCheck]
    public IActionResult Index()
    {
        int? uuid = HttpContext.Session.GetInt32("uuid");
        if (uuid > 0)
        {
            return RedirectToAction("Dashboard");
        }

        MyViewModel MyModel = new MyViewModel();
        return View("Index", MyModel);
    }

    // ******************* USER SECTION *******************
    [HttpPost("user/create")]
    public IActionResult CreateUser(User NewUser)
    {
        if (!ModelState.IsValid)
        {
            return Index();
        }
        PasswordHasher<User> Hasher = new PasswordHasher<User>();
        NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
        _context.Add(NewUser);
        _context.SaveChanges();
        HttpContext.Session.SetInt32("uuid", NewUser.UserId);
        return RedirectToAction("Dashboard");
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
                return Index();
            }

            PasswordHasher<Login> hasher = new PasswordHasher<Login>();

            var result = hasher.VerifyHashedPassword(NewLogin, userInDb.Password, NewLogin.PasswordLogin);

            System.Console.WriteLine(NewLogin.PasswordLogin);

            if (result == 0)
            {
                ModelState.AddModelError("PasswordLogin", "Invalid Email/Password -> Password");
                return Index();
            }
            HttpContext.Session.SetInt32("uuid", userInDb.UserId);
            return RedirectToAction("Dashboard");
        }
        else
        {
            return Index();
        }
    }

    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    // ******************* DASHBOARD SECTION *******************
    [SessionCheck]
    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        int? uuid = HttpContext.Session.GetInt32("uuid");
        MyViewModel MyModel = new MyViewModel
        {
            User = _context.Users.FirstOrDefault(u => u.UserId == (int)uuid),
            AllWeddings = _context.Weddings
                .Include(w => w.AllUsers)
                .ThenInclude(w => w.User)
                .ToList()
        };
        return View("Dashboard", MyModel);
    }
    // ******************* ASSOCIATION SECTION *******************
    [HttpPost("/association")]
    public IActionResult AssociationCreate(int WeddingId)
    {
        int? uuid = HttpContext.Session.GetInt32("uuid");
        if (uuid != null)
        {
            Association? potentialAssociation = _context.Associations.FirstOrDefault(a => a.WeddingId == WeddingId && a.UserId == uuid);
            if (potentialAssociation != null)
            {
                Association? association = _context.Associations.FirstOrDefault(a => a.UserId == uuid && a.WeddingId == WeddingId);
                if (association != null)
                {
                    _context.Remove(association);
                    _context.SaveChanges();
                }
            }
            else
            {
                Association association = new Association
                {
                    WeddingId = WeddingId,
                    UserId = (int)uuid
                };
                _context.Add(association);
                _context.SaveChanges();
            }
        }
        return RedirectToAction("Dashboard");
    }

    // ******************* WEDDING SECTION *******************
    [HttpGet("/wedding/new")]
    public IActionResult WeddingNew()
    {
        int? uuid = HttpContext.Session.GetInt32("uuid");
        MyViewModel MyModel = new MyViewModel
        {
            User = _context.Users.FirstOrDefault(u => u.UserId == uuid),
        };
        return View("WeddingNew", MyModel);
    }

    [HttpPost("/wedding/create")]
    public IActionResult WeddingCreate(Wedding NewWedding)
    {
        if (!ModelState.IsValid)
        {
            return WeddingNew();
        }
        _context.Add(NewWedding);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpGet("/wedding/{WeddingId}")]
    public IActionResult WeddingShow(int WeddingId)
    {
        int? uuid = HttpContext.Session.GetInt32("uuid");
        MyViewModel MyModel = new MyViewModel
        {
            User = _context.Users.FirstOrDefault(u => u.UserId == uuid),
            Wedding = _context.Weddings.FirstOrDefault(w => w.WeddingId == WeddingId)
        };
        return View("WeddingShow", MyModel);
    }
}

public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("uuid");
        // Check to see if we got back null
        if (userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
        // else {
        //     context.Result = new RedirectToActionResult("Dashboard", "Home", null);
        // }
    }
}