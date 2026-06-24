using Microsoft.EntityFrameworkCore;
using CodeFirst1.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Register DbContext with connection string from configuration
var connectionString = builder.Configuration.GetConnectionString("DBCS");
if (string.IsNullOrWhiteSpace(connectionString))
{
    // Fallback to a sensible default for development if not present
    connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CodeFirstDb1;Trusted_Connection=True;MultipleActiveResultSets=true";
}
builder.Services.AddDbContext<StudentDBContext>(options =>
    options.UseSqlServer(connectionString));

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
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
