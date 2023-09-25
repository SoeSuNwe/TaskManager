
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskCRUDContoller.Controllers;

namespace TaskCRUDContoller.Pages.Task
{
 
    public class IndexModel : PageModel
    {
        private readonly  Data.AppDbContext _context; 

        public IndexModel(Data.AppDbContext context)
        {
            _context = context; 
        }


        public IList<Models.Task> Task { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.Tasks != null)
            {
                Task = await _context.Tasks.ToListAsync();
                return Page();
            }
            return NotFound();
        }

    }
}
