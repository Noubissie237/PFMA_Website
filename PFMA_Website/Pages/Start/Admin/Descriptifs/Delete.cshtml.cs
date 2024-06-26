﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PFMA_Website.Model;
using System.Threading.Tasks;

namespace PFMA_Website.Pages.Start.Admin.Descriptifs
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly PFMA_Website.Data.DataContext _context;

        public DeleteModel(PFMA_Website.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Descriptif Descriptif { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Descriptif = await _context.Descriptifs.FirstOrDefaultAsync(m => m.DescriptifID == id);

            if (Descriptif == null)
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

            Descriptif = await _context.Descriptifs.FindAsync(id);

            if (Descriptif != null)
            {
                _context.Descriptifs.Remove(Descriptif);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
