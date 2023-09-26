using Microsoft.EntityFrameworkCore;
using TaskManager.Data;

namespace TaskManager.Repositories
{
    public interface ITaskRepository
    {
        Task<Models.Task> GetTaskByIdAsync(int id);
        Task CreateTaskAsync(Models.Task task);
        Task EditTaskAsync(Models.Task task);
        Task DeleteTaskAsync(Models.Task task);
        bool HasAccess(string userName);
        bool TaskExists(int id);
    }
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool HasAccess(string userName)
        {
            // Implement access logic here
            return _context.Users.Any(u => u.UserName == userName);
        }
        public async Task CreateTaskAsync(Models.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }
        public async Task EditTaskAsync(Models.Task task)
        {
            _context.Attach(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(Models.Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<Models.Task> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(m => m.TaskId == id);
        }
        public bool TaskExists(int id)
        {
            return (_context.Tasks?.Any(e => e.TaskId == id)).GetValueOrDefault();
        }
    }
}
