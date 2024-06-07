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
    public class IndexModel : PageModel
    {
        private readonly PFMA_Website.Data.DataContext _context;

        public IndexModel(PFMA_Website.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Producteur> Producteur { get;set; }

        public async Task OnGetAsync()
        {
            Producteur = await _context.Producteurs.ToListAsync();
        }
    }
}
