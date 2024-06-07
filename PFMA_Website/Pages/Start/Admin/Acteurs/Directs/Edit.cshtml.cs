using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PFMA_Website.Data;
using PFMA_Website.Model.Acteurs.Directs;

namespace PFMA_Website.Pages.Admin.Acteurs.Directs
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly PFMA_Website.Data.DataContext _context;

        public EditModel(PFMA_Website.Data.DataContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Producteur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProducteurExists(Producteur.ProducteurID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProducteurExists(int id)
        {
            return _context.Producteurs.Any(e => e.ProducteurID == id);
        }
    }
}
