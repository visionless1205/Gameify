using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gameify.Data;
using Gameify.Models;

namespace Gameify.Pages.Platforms
{
    public class IndexModel : PageModel
    {
        private readonly Gameify.Data.GameifyContext _context;

        public IndexModel(Gameify.Data.GameifyContext context)
        {
            _context = context;
        }

        public IList<Platform> Platform { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Platform = await _context.Platform.ToListAsync();
        }
    }
}
