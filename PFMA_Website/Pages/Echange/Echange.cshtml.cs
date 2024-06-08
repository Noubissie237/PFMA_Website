using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PFMA_Website.Pages.Echange
{
    [Authorize]
    public class EchangeModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
