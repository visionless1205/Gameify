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
    public class DetailsModel : PageModel
    {
        private readonly Gameify.Data.GameifyContext _context;

        public DetailsModel(Gameify.Data.GameifyContext context)
        {
            _context = context;
        }

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
    }
}
