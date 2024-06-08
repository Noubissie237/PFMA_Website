﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PFMA_Website.Data;
using PFMA_Website.Model;

namespace PFMA_Website.Pages.Start.Admin.Actualites
{
    public class DeleteModel : PageModel
    {
        private readonly PFMA_Website.Data.DataContext _context;

        public DeleteModel(PFMA_Website.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Actualite Actualite { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actualite = await _context.Actualites.FirstOrDefaultAsync(m => m.ActualiteID == id);

            if (Actualite == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actualite = await _context.Actualites.FindAsync(id);

            if (Actualite != null)
            {
                _context.Actualites.Remove(Actualite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}