using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PFMA_Website.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PFMA_Website.Pages.Admin.Users
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly PFMA_Website.Data.DataContext _context;

        public IndexModel(PFMA_Website.Data.DataContext context)
        {
            _context = context;
        }

#pragma warning disable CS0108 // Un membre masque un membre hérité ; le mot clé new est manquant
        public IList<User> User { get; set; }
#pragma warning restore CS0108 // Un membre masque un membre hérité ; le mot clé new est manquant

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}
