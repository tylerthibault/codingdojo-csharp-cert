#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _28Exam1.Models;
public class MyViewModel
{
    public User User {get;set;}
    public Login Login {get;set;}
    public Post Post {get;set;}
    public Association Association {get;set;}

    public List<User> AllUsers {get;set;}
    public List<Post> AllPosts {get;set;}
}