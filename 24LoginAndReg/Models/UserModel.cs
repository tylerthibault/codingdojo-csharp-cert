#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;
namespace _24LoginAndReg.Models;
public class User
{
    [Key]
    public int UserId {get;set;}

    [Required(ErrorMessage="First Name is required")]
    [MinLength(3, ErrorMessage="First Name must be at least 3 characters in length")]
    public string FirstName {get;set;}

    [Required(ErrorMessage="Last Name is required")]
    [MinLength(3, ErrorMessage="Last Name must be at least 3 characters in length")]
    public string LastName {get;set;}
    
    [Required(ErrorMessage="Email is required")]
    [EmailAddress]
    public string Email {get;set;}
    
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage="Password Must be 8 characters long")]
    public string Password {get;set;}

    [NotMapped]
    [Compare("Password")]
    public string PasswordConfirm {get;set;}
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