using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gameify.Data;
using Gameify.Models;

namespace Gameify.Pages.Developers
{
    public class CreateModel : PageModel
    {
        private readonly Gameify.Data.GameifyContext _context;

        public CreateModel(Gameify.Data.GameifyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Developer Developer { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Developer.Add(Developer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
