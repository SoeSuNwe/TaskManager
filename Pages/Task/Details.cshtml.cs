using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;

namespace TaskManager.Pages.Task
{
	public class DetailsModel : PageModel
	{
		private readonly ITaskRepository _taskRepository;

		public DetailsModel(ITaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}
		public Models.Task Task { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
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
			Task = task;
			return Page();
		}
	}
}
