using System.Text;
using System;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;

namespace PFMA_Website.Model
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        public string genre { get; set; }
        private string _password;
        [StringLength(50, MinimumLength = 8)]
        public string password
        {
            get { return _password; }
            set
            {
                using (var sha256 = SHA256.Create())
                {
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                    _password = Convert.ToBase64String(hashedBytes);
                }
            }
        }
    }
}
