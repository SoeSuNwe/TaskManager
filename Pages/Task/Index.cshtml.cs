
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManager.Controllers;

namespace TaskManager.Pages.Task
{

    public class IndexModel : PageModel
    {
        private readonly Data.AppDbContext _context;
        public bool IsAscendingOrder { get; set; } = true; 

        public IndexModel(Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Models.Task> Tasks { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.Tasks != null)
            {
                Tasks = await _context.Tasks.OrderBy(item => item.DueDate).ToListAsync();
                return Page();
            }
            return NotFound();
        }

        public async Task<IActionResult> OnPostSortAsync(String sortOrder)
        {
            Console.WriteLine(sortOrder); 
            if (sortOrder=="True")
            {
                Tasks = await _context.Tasks.OrderBy(item => item.DueDate).ToListAsync();
                IsAscendingOrder = false;
            }
            else
            {
                Tasks = await _context.Tasks.OrderByDescending(item => item.DueDate).ToListAsync();
                IsAscendingOrder = true;
            } 
           

            return Page(); // Return a Page result to refresh the page with the updated data
        }

    }
}
