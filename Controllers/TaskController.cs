using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskCRUDContoller.Data; 

namespace TaskCRUDContoller.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;
       // private readonly ITaskRepository _taskRepository;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize(Policy = "RequireAdminRole")] // Require the "RequireAdminRole" policy for this action
        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            Console.WriteLine(userName);

            var tasks =_context.Tasks.Select(t=>t);
            return View(tasks);
        }

       
        
    }
    //public class TaskController : Controller
    //{
    //    private readonly List<string> tasks = new List<string>
    //    {
    //        "Task 1",
    //        "Task 2",
    //        "Task 3"
    //    };

    //    public IActionResult Index()
    //    {
    //        return View(tasks);
    //    }

    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    public IActionResult Create(string task)
    //    {
    //        tasks.Add(task);
    //        return RedirectToAction("Index");
    //    }

    //    public IActionResult Edit(int id)
    //    {
    //        if (id >= 0 && id < tasks.Count)
    //        {
    //            string task = tasks[id];
    //            return View("Edit", task);
    //        }
    //        return RedirectToAction("Index");
    //    }

    //    [HttpPost]
    //    public IActionResult Edit(int id, string task)
    //    {
    //        if (id >= 0 && id < tasks.Count)
    //        {
    //            tasks[id] = task;
    //        }
    //        return RedirectToAction("Index");
    //    }

    //    public IActionResult Delete(int id)
    //    {
    //        if (id >= 0 && id < tasks.Count)
    //        {
    //            tasks.RemoveAt(id);
    //        }
    //        return RedirectToAction("Index");
    //    }
    //}
}
