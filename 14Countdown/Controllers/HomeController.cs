// This brings all the MVC features we need to this file

using Microsoft.AspNetCore.Mvc;

namespace Countdown.Controllers;

public class HomeController : Controller   // Remember inheritance?    

{
    [HttpGet("")]
    public ViewResult Index()
    {
        DateTime CurrentTime = DateTime.Now;
        String StringCurrentTime = CurrentTime.ToString("MMMM dd yyyy");
        ViewBag.CurrentTime = StringCurrentTime;

        DateTime EndTime = new DateTime(2023, 10,18);
        String StringEndTime = EndTime.ToString("MMMM dd yyyy");
        ViewBag.EndTime = StringEndTime;

        TimeSpan t = EndTime.Subtract(CurrentTime);
        double Days = Math.Floor(t.TotalDays);
        double Hours = Math.Floor(t.TotalHours - (Days * 24));
        
        ViewBag.Days = Days;
        ViewBag.Hours = Hours;
        return View();
    }
}

