using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManager.Repositories;

namespace TaskManager.Pages.Task
{
    public class CreateModel : PageModel
	{
		private readonly ITaskRepository _taskRepository;

		public CreateModel(ITaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}

		[BindProperty]
		public Models.Task Task { get; set; } = default!;


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		[Authorize]
		public async Task<IActionResult> OnPostAsync()
		{
			if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
			{
				if (_taskRepository.HasAccess(User.Identity.Name)) {
					if (!ModelState.IsValid || Task == null)
					{
						return Page();
					}
					await _taskRepository.CreateTaskAsync(Task);
					return RedirectToPage("./Index");
				}
				return Forbid();
			}
			return Forbid();

		}
	}
}
