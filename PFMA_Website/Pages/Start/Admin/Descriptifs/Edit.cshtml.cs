using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PFMA_Website.Data;
using PFMA_Website.Model;

namespace PFMA_Website.Pages.Start.Admin.Descriptifs
{
    public class EditModel : PageModel
    {
        private readonly PFMA_Website.Data.DataContext _context;

        public EditModel(PFMA_Website.Data.DataContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Descriptif).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescriptifExists(Descriptif.DescriptifID))
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

        private bool DescriptifExists(int id)
        {
            return _context.Descriptifs.Any(e => e.DescriptifID == id);
        }
    }
}
