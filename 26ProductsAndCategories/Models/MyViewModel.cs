#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _26ProductsAndCategories.Models;
public class MyViewModel
{
    public Product Product {get;set;}
    public Category Category {get;set;}
    public Association Association {get;set;}


    public List<Product> AllProducts {get;set;}
    public List<Category> AllCategories {get;set;}
}