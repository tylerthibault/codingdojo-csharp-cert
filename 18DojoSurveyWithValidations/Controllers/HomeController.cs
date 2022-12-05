using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _18DojoSurveyWithValidations.Models;

namespace _18DojoSurveyWithValidations.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static Form FormInfo = new Form();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("/form/process")]
    public IActionResult ProcessForm(Form newForm)
    {
        if (ModelState.IsValid)
        {

            Form NewFormInfo = new Form()
            {
                Name = newForm.Name,
                Loc = newForm.Loc,
                Lang = newForm.Lang,
                Comment = newForm.Comment,
            };
            FormInfo = NewFormInfo;
            return RedirectToAction("Results");
        } 
        else {
            return View("Index");
        }
    }

    [HttpGet("/results")]
    public IActionResult Results()
    {
        return View("Results", FormInfo);
    }
}
