using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; 
using TaskCRUDContoller.Data; 

namespace TaskCRUDContoller.Pages.Task
{
    public class CreateModel : PageModel
    {
        private readonly  AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }
 
        [BindProperty]
        public Models.Task Task { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        [Authorize]
        public async Task<IActionResult> OnPostAsync()
        {
            var userName = User.Identity.Name;
            var hasAccess = _context.Users.Any(u => u.UserName == userName);
            if (hasAccess)
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
