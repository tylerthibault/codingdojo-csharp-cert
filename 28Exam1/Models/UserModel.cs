#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace _28Exam1.Models;
public class User
{
    [Key]
    public int UserId { get; set; }



    [Required(ErrorMessage = "Name is required")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters in length")]
    public string Name { get; set; }


    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    [EmailUnique]
    public string Email { get; set; }


    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password Must be 8 characters long")]
    [SecurePassword]
    public string Password { get; set; }

    [NotMapped]
    [Required(ErrorMessage = "Confirm Password is required")]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

    public List<Like> AllPosts { get; set; } = new List<Like>();
}

public class SecurePasswordAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // convert incoming object to correct datatype
        string pass = (string)value;
        HashSet<char> specialCharacters = new HashSet<char>() { '%', '$', '#', '!' };

        if (pass.Any(char.IsLower) && 
            pass.Any(char.IsUpper) &&
            pass.Any(char.IsDigit) &&
            pass.Any(specialCharacters.Contains)) // validation condition 
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("Not a secure Password");
        }
    }
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
        if (_context.Users.Any(e => e.Email == value.ToString()))
        {
            // If yes, throw an error
            return new ValidationResult("Email must be unique!");
        }
        else
        {
            // If no, proceed
            return ValidationResult.Success;
        }
    }
}