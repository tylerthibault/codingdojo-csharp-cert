#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _27WeddingPlanner.Models;
public class MyViewModel
{
    public User User {get;set;}
    public Login Login {get;set;}
    public Wedding Wedding {get;set;}
    public Association Association {get;set;}

    public List<User> AllUsers {get;set;}
    public List<Wedding> AllWeddings {get;set;}
}