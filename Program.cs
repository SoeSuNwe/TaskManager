using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskCRUDContoller;
using TaskCRUDContoller.Data; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// Configure authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Customize the login path
        options.AccessDeniedPath = "/Account/AccessDenied"; // Customize the access denied path
    });

// Configure authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireLoggedIn", policy => policy.RequireAuthenticatedUser());
    options.AddPolicy("RequireAdminRole", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Admin");
    });
});


string connectionString = builder.Configuration.GetConnectionString("SQLiteConnection") ??
    throw new InvalidOperationException("Connection string 'SQLiteConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));


// Configure Identity services and options
//builder.Services.ConfigureIdentity(); // Call the extension method
// Configure Identity services and options
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Configure Identity options here
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    // Add other configuration options as needed
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Add this to enable authentication
app.UseAuthorization();  // Add this to enable authorization

app.MapRazorPages();
app.MapDefaultControllerRoute();

// Configure routing for TaskController
app.MapControllerRoute(
    name: "taskRoute",
    pattern: "task/{action}/{id?}",
    defaults: new { controller = "Task" });

app.Run();

//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Mvc;
//using System;

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        CreateHostBuilder(args).Build().Run();
//    }

//    public static IHostBuilder CreateHostBuilder(string[] args) =>
//        Host.CreateDefaultBuilder(args)
//            .ConfigureWebHostDefaults(webBuilder =>
//            {
//                webBuilder.ConfigureServices((context, services) =>
//                {
//                    services.AddControllersWithViews();
//                    services.AddRazorPages().AddRazorRuntimeCompilation();
//                    string connectionString = builder.Configuration.GetConnectionString("SQLiteConnection") ??
//                            throw new InvalidOperationException("Connection string 'SQLiteConnection' not found.");
//                    builder.Services.AddDbContext<AppDbContext>(options =>
//                        options.UseSqlite(connectionString));
//                })
//                .Configure(app =>
//                {
//                    app.UseRouting();

//                    // Define a custom endpoint for the TaskController
//                    app.UseEndpoints(endpoints =>
//                    {
//                        endpoints.MapControllerRoute(
//                            name: "Task",
//                            pattern: "Task/{action}/{id?}",
//                            defaults: new { controller = "Task", action = "Index" });

//                        // Add other endpoints and middleware as needed.

//                        endpoints.MapControllers();
//                        endpoints.MapRazorPages();
//                    });
//                });
//            });
//}







//using TaskCRUDContoller;

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        CreateHostBuilder(args).Build().Run();
//    }

//    public static IHostBuilder CreateHostBuilder(string[] args) =>
//        Host.CreateDefaultBuilder(args)
//            .ConfigureWebHostDefaults(webBuilder =>
//            {
//                webBuilder.UseStartup<Startup>(); // This line sets the Startup class.
//            });
//}