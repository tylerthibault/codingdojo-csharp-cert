#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _19DateValidator.Models;
public class Date
{
    [Required(ErrorMessage="Date is required")]
    // [MinLength(3, ErrorMessage="Name must be at least 3 characters in length")]
    public DateTime CheckDate {get;set;}

    public static bool Checker(DateTime IncomingDate)
    {
        DateTime now = DateTime.Now;
        System.Console.WriteLine($"now: {now} || incomming: {IncomingDate} ");
        if (now > IncomingDate)
        {
            System.Console.WriteLine("smaller");
            return true;
        }
        else 
        {
            System.Console.WriteLine("bigger");
            return false;
        }
    }
}