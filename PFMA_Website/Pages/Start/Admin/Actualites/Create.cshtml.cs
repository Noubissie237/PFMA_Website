﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PFMA_Website.Model;
using System.Threading.Tasks;

namespace PFMA_Website.Pages.Start.Admin.Actualites
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly PFMA_Website.Data.DataContext _context;

        public CreateModel(PFMA_Website.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Actualite Actualite { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Actualites.Add(Actualite);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
