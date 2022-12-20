using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using _28Exam1.Models;
using Microsoft.EntityFrameworkCore;

namespace _28Exam1.Controllers;

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

    // ********************** DASHBOARD SECTION

    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllPosts = _context.Posts
                .Include(p => p.User)
                .Include(p => p.AllUsers)
                .ThenInclude(p => p.User)
                .ToList(),
        };
        ViewBag.uuid = HttpContext.Session.GetInt32("uuid");
        return View("Dashboard", MyModel);
    }

    // ********************** USER SECTION
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

    // ********************** POST SECTION
    [HttpGet("/post/new")]
    public IActionResult PostNew()
    {
        return View("PostNew");
    }

    [HttpPost("/post/create")]
    public IActionResult PostCreate(Post NewPost)
    {
        if (!ModelState.IsValid)
        {
            return PostNew();
        }
        int? uuid = HttpContext.Session.GetInt32("uuid");
        if (uuid != null)
        {
            NewPost.UserId = (int)uuid;
            _context.Add(NewPost);
            _context.SaveChanges();
        }
        return RedirectToAction("Dashboard");
    }

    [HttpGet("/post/{PostId}/edit")]
    public IActionResult PostEdit(int PostId)
    {
        Post post = _context.Posts.FirstOrDefault(p => p.PostId == PostId);
        return View("PostEdit", post);
    }

    [HttpGet("/post/{PostId}")]
    public IActionResult PostShow(int PostId)
    {
        Post post = _context.Posts.Include(p => p.User).FirstOrDefault(p => p.PostId == PostId);
        ViewBag.uuid = HttpContext.Session.GetInt32("uuid");
        return View("PostShow", post);
    }

    [HttpGet("/post/{PostId}/delete")]
    public IActionResult PostDelete(int PostId)
    {
        Post post = _context.Posts.FirstOrDefault(p => p.PostId == PostId);
        _context.Posts.Remove(post);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    // ********************** LIKE SECTION
    [HttpGet("/like/{PostId}")]
    public IActionResult Like(int PostId)
    {
        int? uuid = HttpContext.Session.GetInt32("uuid");
        if (uuid != null)
        {
            Like? potentialLike = _context.Likes.FirstOrDefault(l => l.UserId == uuid && l.PostId == PostId);
            if (potentialLike == null)
            {
                Like? like = new Like
                {
                    PostId = PostId,
                    UserId = (int)uuid
                };

                _context.Likes.Add(like);
                _context.SaveChanges();
            }
            else 
            {
                _context.Likes.Remove(potentialLike);
                _context.SaveChanges();
            }
        }
        return RedirectToAction("Dashboard");
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