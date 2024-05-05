using Microsoft.EntityFrameworkCore;
using Vrika.Models;


    public class ShippingDbContext : DbContext     //inheritance
    {
        public ShippingDbContext(DbContextOptions<ShippingDbContext> options)
            : base(options)
        {
        }


        public DbSet<Shipping> Shippings { get; set; }


    }
/*using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vrika.Models;
@using Microsoft.AspNetCore.Identity
@inject SignInManager<IdentityUser> signInManager
public class ShippingDbContext : IdentityDbContext<ApplicationUser>
{
    public ShippingDbContext(DbContextOptions<ShippingDbContext> options)
        : base(options)
    {
    }

    public DbSet<Shipping> Shippings { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships
        modelBuilder.Entity<Shipping>()
            .HasOne(o => o.User)
            .WithMany(u => u.Shippings)
            .HasForeignKey(o => o.UserId);
    }
}*/
