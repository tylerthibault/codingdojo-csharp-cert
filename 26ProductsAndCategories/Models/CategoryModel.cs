#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _26ProductsAndCategories.Models;
public class Category
{
    [Key]
    public int CategoryId {get;set;}

    [Required(ErrorMessage="Name is required")]
    [MinLength(3, ErrorMessage="Name must be at least 3 characters in length")]
    public string Name {get;set;}
    
    public List<Association> AllProducts {get;set;} = new List<Association>();
    
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}