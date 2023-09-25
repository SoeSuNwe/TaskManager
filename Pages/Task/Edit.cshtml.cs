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
		private readonly AppDbContext _context;

		public EditModel(AppDbContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Models.Task Task { get; set; } = default!;
		[Authorize]
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			var userName = User.Identity.Name;
			var hasAccess = _context.Users.Any(u => u.UserName == userName);
			if (hasAccess)
			{
				if (id == null || _context.Tasks == null)
				{
					return NotFound();
				}

				var task = await _context.Tasks.FirstOrDefaultAsync(m => m.TaskId == id);
				if (task == null)
				{
					return NotFound();
				}
				Task = task;
				return Page();
			}
			return Forbid();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		[Authorize]
		public async Task<IActionResult> OnPostAsync()
		{
			if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
			{
				if (!ModelState.IsValid || _context.Tasks == null || Task == null)
				{
					return Page();
				}
				_context.Attach(Task).State = EntityState.Modified;
				try
				{
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!TaskExists(Task.TaskId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				await _context.SaveChangesAsync();
				return RedirectToPage("./Index");
			}
			return Forbid();
		}

		private bool TaskExists(int id)
		{
			return (_context.Tasks?.Any(e => e.TaskId == id)).GetValueOrDefault();
		}
	}
}
