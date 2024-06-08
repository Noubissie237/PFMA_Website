using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PFMA_Website.Data;
using PFMA_Website.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PFMA_Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DataContext _datacontext;

        public IndexModel(ILogger<IndexModel> logger, DataContext datacontext)
        {
            _logger = logger;
            _datacontext = datacontext;
        }

        public static IList<Actualite> Actualities { get; set; }
        public static IList<Descriptif> DescriptifList { get; set; }

        public async Task OnGetAsync()
        {
            Actualities = await _datacontext.Actualites.ToListAsync();
            DescriptifList = await _datacontext.Descriptifs.ToListAsync();

        }

        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Start");
        }
    }
}
