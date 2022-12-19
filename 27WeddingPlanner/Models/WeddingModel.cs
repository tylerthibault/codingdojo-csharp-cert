#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _27WeddingPlanner.Models;
public class Wedding
{
    [Key]
    public int WeddingId {get;set;}

    [Required(ErrorMessage="Wedder One is required")]
    [MinLength(3, ErrorMessage="Wedder One must be at least 3 characters in length")]
    public string WedderOne {get;set;}

    [Required(ErrorMessage="Wedder One is required")]
    [MinLength(3, ErrorMessage="Wedder One must be at least 3 characters in length")]
    public string WedderTwo {get;set;}

    [Required(ErrorMessage="Date is required")]
    public DateTime Date {get;set;}

    [Required(ErrorMessage="Address is required")]
    public string Address {get;set;}

    public List<Association> AllUsers {get;set;} = new List<Association>();
}