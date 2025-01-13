using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gameify.Data;
using Gameify.Models;

namespace Gameify.Pages.Developers
{
    public class DeleteModel : PageModel
    {
        private readonly Gameify.Data.GameifyContext _context;

        public DeleteModel(Gameify.Data.GameifyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Developer Developer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developer.FirstOrDefaultAsync(m => m.ID == id);

            if (developer == null)
            {
                return NotFound();
            }
            else
            {
                Developer = developer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developer.FindAsync(id);
            if (developer != null)
            {
                Developer = developer;
                _context.Developer.Remove(Developer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
