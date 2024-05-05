using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;   // importing dependencies 

using Vrika.Models;   //importing models 


public class AuthDbContext : IdentityDbContext<IdentityUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
       : base(options)
    {
    }
    // 88910005-e0f9-483d-b60e-ce78f4143081

    protected override void OnModelCreating(ModelBuilder builder) { 
  
       
        base.OnModelCreating(builder);

        // Seed Roles (User, Admin, etc)
        var adminRoleID = "88910005-e0f9-483d-b60e-ce78f4143081";
        var userRoleID = "40c56661-ec64-4e89-b2c2-0ce43fbb5b71";

        var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",  // Change role name to uppercase
                    Id = adminRoleID,
                    ConcurrencyStamp = adminRoleID
                },

                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",   // Change role name to uppercase
                    Id = userRoleID,
                    ConcurrencyStamp = userRoleID
                }
            };

        builder.Entity<IdentityRole>().HasData(roles);

        // Seed admin user
        var adminID = "3c8089d0-77f6-4061-81f0-855d5c5ddac8";
       

        var adminUser = new IdentityUser
        {
            UserName = "sahilaltaf",
            Email = "itxsaaho@gmail.com",
            NormalizedEmail = "itxsaaho@gmail.com".ToUpper(),
            NormalizedUserName = "sahilaltaf".ToUpper(),
            Id = adminID
        };

       

        adminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adminUser, "Sahil@123");
       

        builder.Entity<IdentityUser>().HasData(adminUser);  // Use builder.Entity<IdentityUser>() for user data

        // Add all roles to admin
        var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = userRoleID,
                    UserId = adminID
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleID,
                    UserId = adminID
                }
                
               
            };
       
        builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);  // Use builder.Entity<IdentityUserRole<string>>() for role assignment
    }
}


