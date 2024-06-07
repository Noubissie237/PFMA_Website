using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PFMA_Website.Data;
using System.Text;
using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Options;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace PFMA_Website.Pages
{
    public class ConnexionModel : PageModel
    {
        private readonly DataContext _dataContext;
        public bool displayInvalidAccountMessage = false;
        public ConnexionModel(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public string SecurePassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                password = Convert.ToBase64String(hashedBytes);
            }
            return password;
        }

        public bool UserExist(string email, string password)
        {
            if (_dataContext.Users.Any())
            {
                foreach (var item in _dataContext.Users)
                {
                    if ((item.Email == email) && (item.password == SecurePassword(password)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public async Task<IActionResult> OnPostAsync(string email, string password, string ReturnUrl)
        {
            if (UserExist(email, password))
            {
                var nameReal = "";
                foreach (var item in _dataContext.Users)
                {
                    if (item.Email == email)
                    {
                        nameReal = item.Name;
                    }
                }
                var claims = new List<Claim> { new Claim(ClaimTypes.Name,  nameReal, email) };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                this.displayInvalidAccountMessage = false;
                return Redirect(ReturnUrl == null ? "/Start" : ReturnUrl);
            }
            this.displayInvalidAccountMessage = true;
            return Page();
        }
        public IActionResult OnGet(string ReturnUrl = "/Start")
        {
            if (this.HttpContext.User.Identity.IsAuthenticated)
                return Redirect(ReturnUrl);

            return Page();
        }

    }
}
