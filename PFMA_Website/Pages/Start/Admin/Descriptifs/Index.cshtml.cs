using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PFMA_Website.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PFMA_Website.Pages.Start.Admin.Descriptifs
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly PFMA_Website.Data.DataContext _context;

        public IndexModel(PFMA_Website.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Descriptif> Descriptif { get; set; }

        public async Task OnGetAsync()
        {
            Descriptif = await _context.Descriptifs.ToListAsync();
        }
    }
}
