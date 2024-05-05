using Microsoft.EntityFrameworkCore;
using Vrika.Models;


    public class RequestDbContext : DbContext     //inheritance
    {
        public RequestDbContext(DbContextOptions<RequestDbContext> options)
            : base(options)
        {
        }


        public DbSet<Request> Requests { get; set; }


    }     

