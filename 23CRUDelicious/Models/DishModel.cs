#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _23CRUDelicious.Models;
public class Dish
{
    [Key]
    public int DishId {get;set;}
    // [Required(ErrorMessage="Name is required")]
    // [MinLength(3, ErrorMessage="Name must be at least 3 characters in length")]
    public string Name {get;set;}
    public string Chef {get;set;}
    public int Tastiness {get;set;}
    public int Calories {get;set;}
    public string Description {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}