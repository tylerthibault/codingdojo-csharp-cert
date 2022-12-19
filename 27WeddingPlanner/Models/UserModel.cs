#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace _27WeddingPlanner.Models;
public class User
{
    [Key]
    public int UserId {get;set;}

    [Required(ErrorMessage="First Name is required")]
    [MinLength(3, ErrorMessage="First Name must be at least 3 characters in length")]
    public string FirstName {get;set;}


    [Required(ErrorMessage="Last Name is required")]
    [MinLength(3, ErrorMessage="First Name must be at least 3 characters in length")]
    public string LastName {get;set;}


    [Required(ErrorMessage="Email is required")]
    [EmailAddress]
    [EmailUnique]
    public string Email {get;set;}


    [Required(ErrorMessage="Password is required")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage="Password Must be 8 characters long")]
    public string Password {get;set;}

    [NotMapped]
    [Required(ErrorMessage="Confirm Password is required")]
    [Compare("Password")]
    public string ConfirmPassword {get;set;}

    public List<Association> AllWeddings {get;set;} = new List<Association>();
}

public class EmailUniqueAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // convert incoming object to correct datatype

        if (value == null)
        {
            return new ValidationResult("Email is required");
        }

        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
       if(_context.Users.Any(e => e.Email == value.ToString()))
        {
    	    // If yes, throw an error
            return new ValidationResult("Email must be unique!");
        } else {
    	    // If no, proceed
            return ValidationResult.Success;
        }
    }
}