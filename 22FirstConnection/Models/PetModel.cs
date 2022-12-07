#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _22FirstConnection.Models;
public class Pet
{
    [Key]
    public int PetId {get; set;}
    // [Required(ErrorMessage="Name is required")]
    // [MinLength(3, ErrorMessage="Name must be at least 3 characters in length")]
    public string Name {get;set;}
    public string Type {get;set;}
    public int Age {get;set;}
    public bool hasFur {get;set;}
}