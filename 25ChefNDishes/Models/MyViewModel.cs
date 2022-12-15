#pragma warning disable CS8618
namespace _25ChefNDishes.Models;

public class MyViewModel
{    
    public Dish Dish {get;set;}
    public Chef Chef {get;set;}
    
    public List<Chef> AllChefs {get;set;}
    public List<Dish> AllDishes {get;set;}
}