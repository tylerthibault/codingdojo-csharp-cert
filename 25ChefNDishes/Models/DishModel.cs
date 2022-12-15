#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _25ChefNDishes.Models;
public class Dish
{
    [Key]
    public int DishId {get;set;}

    [Required(ErrorMessage="Name is required")]
    [MinLength(3, ErrorMessage="Name must be at least 3 characters in length")]
    public string Name {get;set;}

    [Required(ErrorMessage="Calories is required")]
    [Range(1,int.MaxValue, ErrorMessage = "Must be greater than 0")]
    public int Calories {get;set;}

    [Required(ErrorMessage="Tastiness is required")]
    [Range(1,6, ErrorMessage = "Must be between 1 and 5")]
    public int Tastiness {get;set;}

    [Required(ErrorMessage="Chef is required")]
    public int ChefId {get;set;}
    public Chef? Chef {get;set;}
}
