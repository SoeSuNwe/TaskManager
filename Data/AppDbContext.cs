using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore; 

namespace TaskManager.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Task> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=taskmanger.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            List<Models.Task> tasks = new();
            for (int i = 1; i <= 10; i++)
            {
                tasks.Add(
                    new Models.Task
                    {
                        TaskId = i,
                        Title = "Task " + i,
                        Description = "This is Task " + i,
                        DueDate = DateTime.Now.AddDays(i),
                        IsCompleted = (i % 2 == 0)

                    }
                );
            }
            modelBuilder.Entity<Models.Task>().HasData(tasks);
        }

    }
}
