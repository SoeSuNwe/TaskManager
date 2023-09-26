using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;

namespace TaskManager.Pages.Account
{
	public class AboutModel : PageModel
	{
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly AppDbContext _context;
		public String? UserName { get; set; } = default!;

		public AboutModel(SignInManager<IdentityUser> signInManager, AppDbContext context)
		{
			_signInManager = signInManager;
			_context = context;			
		}

		public async Task<IActionResult> OnPostAsync()
		{ 
			// Sign the user out
			await _signInManager.SignOutAsync();

			// Redirect to a page after successful logout
			return RedirectToPage("/Task/Index");
		}



		public async Task<IActionResult> OnPostDeleteAsync()
		{ 
			var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name); 
			if (user != null)
			{
				_context.Users.Remove(user);
				await _context.SaveChangesAsync(); 
				return RedirectToPage("/Task/Index");
			}
			return Page();
			
		}
	}
}
