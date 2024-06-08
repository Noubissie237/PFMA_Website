using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PFMA_Website.Model;
using System.Threading.Tasks;

namespace PFMA_Website.Pages.Admin.Users
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
#pragma warning disable CS0108 // Un membre masque un membre hérité ; le mot clé new est manquant
        public User User { get; set; }
#pragma warning restore CS0108 // Un membre masque un membre hérité ; le mot clé new est manquant

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FirstOrDefaultAsync(m => m.UserID == id);

            if (User == null)
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

            User = await _context.Users.FindAsync(id);

            if (User != null)
            {
                _context.Users.Remove(User);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
