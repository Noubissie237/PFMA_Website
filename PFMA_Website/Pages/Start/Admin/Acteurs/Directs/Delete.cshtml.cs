using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PFMA_Website.Data;
using PFMA_Website.Model.Acteurs.Directs;

namespace PFMA_Website.Pages.Admin.Acteurs.Directs
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
        public Producteur Producteur { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producteur = await _context.Producteurs.FirstOrDefaultAsync(m => m.ProducteurID == id);

            if (Producteur == null)
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

            Producteur = await _context.Producteurs.FindAsync(id);

            if (Producteur != null)
            {
                _context.Producteurs.Remove(Producteur);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
