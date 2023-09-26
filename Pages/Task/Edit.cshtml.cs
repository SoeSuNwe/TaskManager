using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Pages.Task
{
	public class EditModel : PageModel
	{
		private readonly ITaskRepository _taskRepository;

		public EditModel(ITaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}

		[BindProperty]
		public Models.Task Task { get; set; } = default!;
		[Authorize]
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


		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		[Authorize]
		public async Task<IActionResult> OnPostAsync()
		{
			if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
			{
				if (_taskRepository.HasAccess(User.Identity.Name))
				{
					if (!ModelState.IsValid || Task == null)
					{
						return Page();
					}
					try
					{
						await _taskRepository.EditTaskAsync(Task);
					}
					catch (DbUpdateConcurrencyException)
					{
						if (!_taskRepository.TaskExists(Task.TaskId))
						{
							return NotFound();
						}
						else
						{
							throw;
						}
					}
					return RedirectToPage("./Index");
				}
				return Forbid();
			}
			return Forbid();
		}
		
	}
}
