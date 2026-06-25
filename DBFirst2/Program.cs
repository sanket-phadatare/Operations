using DBFirst2.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Register DbContext
builder.Services.AddDbContext<CodeFirstDb1Context>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("CodeFirstDb1Context")
        ?? throw new InvalidOperationException("Connection string 'CodeFirstDb1Context' not found.")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();