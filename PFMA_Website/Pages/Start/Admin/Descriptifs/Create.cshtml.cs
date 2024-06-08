using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PFMA_Website.Data;
using PFMA_Website.Model;

namespace PFMA_Website.Pages.Start.Admin.Descriptifs
{
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
        public Descriptif Descriptif { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Descriptifs.Add(Descriptif);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
