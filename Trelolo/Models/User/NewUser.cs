using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Trelolo.Models.User
{
    public class NewUser
    {
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Les mots de passe sont différents.")]
        public string ConfirmPassword { get; set; }
    }
}
