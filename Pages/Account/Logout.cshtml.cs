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



        //public IActionResult OnPostDeleteUser()
        //{
        //    if (HttpContext.Request.Form.TryGetValue("deleteUserButton", out var value))
        //    {
        //        // Check if the "deleteUserButton" was clicked
        //        if (value.ToString() == "Delete User")
        //        {
        //            // Implement user deletion logic here
        //            // For example, delete the currently logged-in user
        //            var user = _context.Users.FirstOrDefault(u=>u.UserName==User.Identity.Name);
        //            if (user != null)
        //            {
        //                 _context.Remove(user);
        //                _context.SaveChanges();                        
        //            }
        //        }
        //    }
        //    return Page();
        //}
    }
}
