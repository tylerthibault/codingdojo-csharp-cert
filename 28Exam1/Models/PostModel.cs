#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _28Exam1.Models;
public class Post
{
    [Key]
    public int PostId {get;set;}
    
    [Required(ErrorMessage="URL is required")]
    [MinLength(3, ErrorMessage="URL must be at least 3 characters in length")]
    public string URL {get;set;}


    [Required(ErrorMessage="Title is required")]
    [MinLength(3, ErrorMessage="Title must be at least 3 characters in length")]
    public string Title {get;set;}


    [Required(ErrorMessage="Medium is required")]
    [MinLength(3, ErrorMessage="Medium must be at least 3 characters in length")]
    public string Medium {get;set;}


    [Required(ErrorMessage="For Sale is required")]
    public bool ForSale {get;set;}

    public int UserId {get;set;}
    public User? User {get;set;}

    public List<Like> AllUsers {get;set;} = new List<Like>();
}