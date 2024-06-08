using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PFMA_Website.Model;
using System.Linq;
using System.Threading.Tasks;

namespace PFMA_Website.Pages.Start.Admin.Actualites
{
    public class EditModel : PageModel
    {
        private readonly PFMA_Website.Data.DataContext _context;

        public EditModel(PFMA_Website.Data.DataContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Actualite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActualiteExists(Actualite.ActualiteID))
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

        private bool ActualiteExists(int id)
        {
            return _context.Actualites.Any(e => e.ActualiteID == id);
        }
    }
}
