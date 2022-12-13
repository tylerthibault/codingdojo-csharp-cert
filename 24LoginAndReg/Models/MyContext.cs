#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;

namespace _24LoginAndReg.Models;

public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }   
    
    // We need to create a new DbSet<Model> for every model in our project that is making a table
    public DbSet<User> Users { get; set; } 
}
