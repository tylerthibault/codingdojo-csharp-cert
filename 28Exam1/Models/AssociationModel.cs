#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _28Exam1.Models;
public class Association
{
    [Key]
    public int AssociationId {get;set;}

    [Required]
    public int PostId {get;set;}
    
    [Required]
    public int UserId {get;set;}
    
    public Post? Post {get;set;}
    public User? User {get;set;}
}