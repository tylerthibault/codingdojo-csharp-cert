#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _28Exam1.Models;
public class Login
{
    [Required(ErrorMessage="Email is required")]
    [EmailAddress]
    public string EmailLogin {get;set;}

    [Required]
    public string PasswordLogin {get;set;}
}