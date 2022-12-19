#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;

namespace _26ProductsAndCategories.Models;

public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }   
    
    // We need to create a new DbSet<Model> for every model in our project that is making a table
    public DbSet<Product> Products { get; set; } 
    public DbSet<Category> Categories { get; set; } 
    public DbSet<Association> Associations { get; set; } 
}
