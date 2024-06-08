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
    public class IndexModel : PageModel
    {
        private readonly PFMA_Website.Data.DataContext _context;

        public IndexModel(PFMA_Website.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Descriptif> Descriptif { get;set; }

        public async Task OnGetAsync()
        {
            Descriptif = await _context.Descriptifs.ToListAsync();
        }
    }
}
