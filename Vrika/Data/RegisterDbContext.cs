using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;   // importing dependencies 

using Vrika.Models;   //importing models 

public class RegistrationsDbContext : DbContext     //inheritance
{
    public RegistrationsDbContext(DbContextOptions<RegistrationsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Books> Booklist { get; set; }
    

} 