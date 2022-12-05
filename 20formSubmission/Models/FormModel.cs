#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _20formSubmission.Models;

public class Form
{
    [Required(ErrorMessage = "Name is required")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters in length")]
    public string Name { get; set; }

    // [Required(ErrorMessage="Email is required")]
    [EmailAddress]
    public string Email { get; set; }

    // [Required(ErrorMessage="Date of Birth is required")]
    [FutureDate]
    public DateTime DOB { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage="Password must be more than 8 characters long")]
    public string PW { get; set; }

    [Required(ErrorMessage = "Odd Number is required")]
    [OddNum]
    public int Num { get; set; }
}


public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime DateActual = (DateTime)value;
        DateTime now = DateTime.Now;

        if (DateActual > now)
        {
            return new ValidationResult("Date must be in the Past");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}

public class OddNumAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        int Num = (int)value;
        if (Num % 2 == 0)
        {
            return new ValidationResult("Must be an odd number");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}