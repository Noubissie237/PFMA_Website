using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PFMA_Website.Data;
using PFMA_Website.Model;

namespace PFMA_Website.Pages.Start.Admin.Descriptifs
{
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
