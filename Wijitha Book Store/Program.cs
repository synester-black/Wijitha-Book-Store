using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wijitha_Book_Store.Data;
using Wijitha_Book_Store.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddDbContext<Wijitha_Book_StoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Wijitha_Book_StoreContext")
    ?? throw new InvalidOperationException("Connection string 'Wijitha_Book_StoreContext' not found.")));

// Add services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Enable HSTS for production
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
