
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _21SessionWorkshop.Models;
public class Person
{
    [Required(ErrorMessage="Name is required")]
    [MinLength(3, ErrorMessage="Name must be at least 3 characters in length")]
    public string Name {get;set;}
}