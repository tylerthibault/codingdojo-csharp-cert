
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _25ChefNDishes.Models;
public class Chef
{
    [Key]
    public int ChefId {get;set;}

    [Required(ErrorMessage="First Name is required")]
    [MinLength(3, ErrorMessage="First Name must be at least 3 characters in length")]
    public string FirstName {get;set;}

    [Required(ErrorMessage="Last Name is required")]
    [MinLength(3, ErrorMessage="Last Name must be at least 3 characters in length")]
    public string LastName {get;set;}

    [DOB]
    public DateTime DOB {get;set;}

    public List<Dish> CreatedDishes {get;set;} = new List<Dish>();
}

public class DOBAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // convert incoming object to correct datatype
        DateTime DOB = (DateTime)value;

        if (DateTime.Now.Subtract(DOB).TotalDays < 18) // validation condition 
        {
            return new ValidationResult("Chef must at least 18 years old");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}