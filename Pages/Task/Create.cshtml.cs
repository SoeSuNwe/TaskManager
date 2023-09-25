using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManager.Data;

namespace TaskManager.Pages.Task
{
	public class CreateModel : PageModel
	{
		private readonly AppDbContext _context;

		public CreateModel(AppDbContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Models.Task Task { get; set; }


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		[Authorize]
		public async Task<IActionResult> OnPostAsync()
		{
			if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
			{
				if (!ModelState.IsValid || _context.Tasks == null || Task == null)
				{
					return Page();
				}

				_context.Tasks.Add(Task);
				await _context.SaveChangesAsync();
				return RedirectToPage("./Index");
			}
			return Forbid();

		}
	}
}
