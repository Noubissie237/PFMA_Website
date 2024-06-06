using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PFMA_Website.Data;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography;

namespace PFMA_Website.Pages
{
    public class InscriptionModel : PageModel
    {
        public bool errorMessage = false;
        public bool userExistMessage = false;
        private readonly DataContext _dataContext;

        public InscriptionModel(DataContext dataContext)
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

        public bool UserExist(string email)
        {
            foreach (var item in _dataContext.Users)
            {
                if (item.Email == email)
                {
                    return true;
                }
   
            }
            return false;
        }
        public async Task<IActionResult> OnPostAsync(string username, string email, string genre, string password, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                errorMessage = false;
                if ((_dataContext.Users == null) || (!UserExist(email)))
                {
                    _dataContext.Users.Add(new Model.User
                    {
                        Name = username,
                        Email = email,
                        genre = genre,
                        password = password,

                    });
                    
                    _dataContext.SaveChanges();
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, email) };
                    var claimsIdentity = new ClaimsIdentity(claims, "Login");

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    userExistMessage = false;
                    return Redirect(ReturnUrl == null ? "/Start" : ReturnUrl);
                }
                else
                {
                    userExistMessage = true;
                    return Page();
                }
            }
            errorMessage = true;
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
