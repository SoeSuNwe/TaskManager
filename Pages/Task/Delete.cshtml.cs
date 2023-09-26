using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Pages.Task
{
    //public class DeleteModel : PageModel
    //{
    //    private readonly TaskManager.Data.AppDbContext _context;

    //    public DeleteModel(TaskManager.Data.AppDbContext context)
    //    {
    //        _context = context;
    //    }

    //    [BindProperty]
    //  public Models.Task Task { get; set; } = default!;
    //    [Authorize]
    //    public async Task<IActionResult> OnGetAsync(int? id)
    //    {
    //        var userName = User.Identity.Name;
    //        var hasAccess = _context.Users.Any(u => u.UserName == userName);
    //        if (hasAccess)
    //        {
    //            if (id == null || _context.Tasks == null)
    //        {
    //            return NotFound();
    //        }

    //            var task = await _context.Tasks.FirstOrDefaultAsync(m => m.TaskId == id);

    //            if (task == null)
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                Task = task;
    //            }
    //            return Page();
    //        }
    //        return Forbid();
    //    }
    //    [Authorize]
    //    public async Task<IActionResult> OnPostAsync(int? id)
    //    {
    //        var userName = User.Identity.Name;
    //        var hasAccess = _context.Users.Any(u => u.UserName == userName);
    //        if (hasAccess)
    //        {
    //            if (id == null || _context.Tasks == null)
    //            {
    //                return NotFound();
    //            }
    //            var task = await _context.Tasks.FindAsync(id);

    //            if (task != null)
    //            {
    //                Task = task;
    //                _context.Tasks.Remove(Task);
    //                await _context.SaveChangesAsync();
    //            }

    //            return RedirectToPage("./Index");
    //        }
    //        return Forbid();
    //    }
    //}
    public class DeleteModel : PageModel
	{
		private readonly ITaskRepository _taskRepository;

		public DeleteModel(ITaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}

		public Models.Task Task { get; set; } = default!;

		[Authorize]
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			} 
			if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
			{
				Task = await _taskRepository.GetTaskByIdAsync(id.Value);
				if (!ModelState.IsValid || Task == null)
				{
					return NotFound();
				}
				return Page();
			}
			return Forbid();
		}
		[Authorize]
		public async Task<IActionResult> OnPostAsync(int? id)
		{  
			if (id == null)
			{
				return NotFound();
			}
			if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
			{
				if (_taskRepository.HasAccess(User.Identity.Name))
				{
					Task = await _taskRepository.GetTaskByIdAsync(id.Value);

					if (Task != null)
					{
						await _taskRepository.DeleteTaskAsync(Task);
					}
					return RedirectToPage("./Index");
				}
				return Forbid();
			} 
			return Forbid();
		}
	}
}
