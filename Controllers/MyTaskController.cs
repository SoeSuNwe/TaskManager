using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Controllers
{
	public class MyTaskController : Controller
	{
		private readonly ITaskRepository _taskRepository;

		public MyTaskController(ITaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}

        // GET: MyTask
        //public async Task<IActionResult> Index()
        //{
        //	var allTask = await _taskRepository.GetAllTasks();
        //	return allTask != null ?
        //				View(allTask) :
        //				Problem("Entity set 'AppDbContext.Tasks'  is null.");
        //}
        public async Task<IActionResult> Index(string sortOrder)
        { 
            // Toggle sorting order
            sortOrder = sortOrder == "ascending" ? "descending" : "ascending";
            ViewData["CurrentSort"] = sortOrder;
			Console.WriteLine(sortOrder);

            List<Models.Task> allTask = await _taskRepository.GetAllTasks();
			List<Models.Task> sortedTaskList;

            switch (sortOrder)
            {
                case "descending":
                    sortedTaskList = allTask.OrderByDescending(t => t.DueDate).ToList();
                    break;
                default:
                    sortedTaskList = allTask.OrderBy(t => t.DueDate).ToList();
                    break;
            } 
            return View(sortedTaskList);
        }

        // GET: MyTask/Details/5
        public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var task = await _taskRepository.GetTaskByIdAsync(id.Value);
			if (task == null)
			{
				return NotFound();
			}

			return View(task);
		}

		// GET: MyTask/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: MyTask/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("TaskId,Title,Description,DueDate,IsCompleted")] Models.Task task)
		{
			if (ModelState.IsValid)
			{
				await _taskRepository.CreateTaskAsync(task);				 
				return RedirectToAction(nameof(Index));
			}
			return View(task);
		}

		// GET: MyTask/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var task = await _taskRepository.GetTaskByIdAsync(id.Value);
			if (task == null)
			{
				return NotFound();
			}
			return View(task);
		}

		// POST: MyTask/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("TaskId,Title,Description,DueDate,IsCompleted")] Models.Task task)
		{
			if (id != task.TaskId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _taskRepository.EditTaskAsync(task); 
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_taskRepository.TaskExists(task.TaskId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(task);
		}

		// GET: MyTask/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var task = await _taskRepository.GetTaskByIdAsync(id.Value);
			if (task == null)
			{
				return NotFound();
			}

			return View(task);
		}

		// POST: MyTask/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{  
			var task = await _taskRepository.GetTaskByIdAsync(id);
			if (task != null)
			{
				await _taskRepository.DeleteTaskAsync(task);
			}  
			return RedirectToAction(nameof(Index));
		}	 
	}
}
