using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManager;
using TaskManager.Data; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

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

// Seed the database with sample tasks on application startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); // Create the database if it doesn't exist

    // Check if there are no tasks in the database, then seed it
    if (!dbContext.Tasks.Any())
    {
        var sampleTasks = new List<TaskManager.Models.Task>
        {
            new TaskManager.Models.Task
            {
                Title = "Sample Task 1",
                Description = "This is a sample task 1",
                DueDate = DateTime.Now.AddDays(7),
                IsCompleted = false
            },
            new TaskManager.Models.Task
            {
                Title = "Sample Task 2",
                Description = "This is a sample task 2",
                DueDate = DateTime.Now.AddDays(14),
                IsCompleted = false
            }
        };

        dbContext.Tasks.AddRange(sampleTasks);
        dbContext.SaveChanges();
    }
}


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