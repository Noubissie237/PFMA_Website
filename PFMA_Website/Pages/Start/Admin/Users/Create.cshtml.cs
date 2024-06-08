using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PFMA_Website.Model;
using System.Threading.Tasks;

namespace PFMA_Website.Pages.Admin.Users
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
#pragma warning disable CS0108 // Un membre masque un membre hérité ; le mot clé new est manquant
        public User User { get; set; }
#pragma warning restore CS0108 // Un membre masque un membre hérité ; le mot clé new est manquant

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
