#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _18DojoSurveyWithValidations.Models;

public class Form
{
    [Required(ErrorMessage="Name is required")]
    [MinLength(3, ErrorMessage="Name must be at least 3 characters in length")]
    public string Name {get;set;}
    [Required]
    public string Loc {get;set;}
    [Required]
    public string Lang {get;set;}
    public string Comment {get;set;} 
}