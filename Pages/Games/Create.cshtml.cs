﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gameify.Data;
using Gameify.Models;

namespace Gameify.Pages.Games
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
            ViewData["DeveloperID"] = new SelectList(_context.Set<Developer>(), "ID", "DeveloperName");
            ViewData["PlatformID"] = new SelectList(_context.Set<Platform>(), "ID", "PlatformName");
            return Page();
        }

        [BindProperty]
        public Game Game { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Game.Add(Game);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
