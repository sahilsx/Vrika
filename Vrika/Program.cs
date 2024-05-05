using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);
// adding db context
builder.Services.AddDbContext<RegistrationsDbContext>(options =>
options.UseSqlServer("Data Source=DESKTOP-8B6K3FB;Initial Catalog=registerdb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));


builder.Services.AddDbContext<AuthDbContext>(options =>
options.UseSqlServer("Data Source=DESKTOP-8B6K3FB;Initial Catalog=AuthDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));



builder.Services.AddDbContext<RequestDbContext>(options =>
options.UseSqlServer("Data Source=DESKTOP-8B6K3FB\\SQLSERVER1;Initial Catalog=RequestDbContext;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));


builder.Services.AddDbContext<ShippingDbContext>(options =>
options.UseSqlServer("Data Source=DESKTOP-8B6K3FB;Initial Catalog=PostDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));



builder.Services.AddIdentity<IdentityUser, IdentityRole>()       // identity framework
  .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireDigit = true;

});



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
