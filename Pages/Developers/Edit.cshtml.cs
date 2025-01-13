using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gameify.Data;
using Gameify.Models;

namespace Gameify.Pages.Developers
{
    public class EditModel : PageModel
    {
        private readonly Gameify.Data.GameifyContext _context;

        public EditModel(Gameify.Data.GameifyContext context)
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

            var developer =  await _context.Developer.FirstOrDefaultAsync(m => m.ID == id);
            if (developer == null)
            {
                return NotFound();
            }
            Developer = developer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Developer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeveloperExists(Developer.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeveloperExists(int id)
        {
            return _context.Developer.Any(e => e.ID == id);
        }
    }
}
