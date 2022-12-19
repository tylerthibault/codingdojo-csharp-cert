#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _26ProductsAndCategories.Models;

public class Product
{
    [Key]
    public int ProductId {get;set;}

    [Required(ErrorMessage="Name is required")]
    [MinLength(3, ErrorMessage="Name must be at least 3 characters in length")]
    public string Name {get;set;}

    [Required(ErrorMessage="Description is required")]
    public string Description {get;set;}

    [Required(ErrorMessage="Price is required")]
    [Range(1, int.MaxValue, ErrorMessage="Must be more than 1")]
    public int Price {get;set;}

    public List<Association> AllCategories {get;set;} = new List<Association>();
    
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}