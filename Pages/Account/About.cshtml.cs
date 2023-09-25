using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManager.Data;

namespace TaskManager.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AppDbContext _context;
        
        public LogoutModel(SignInManager<IdentityUser> signInManager, AppDbContext context)
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
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name); 
             
            if (user != null)
            {
                _context.Remove(user);
                _context.SaveChanges();
            }

            return RedirectToPage("/Task/Index");
        }
    }
}
