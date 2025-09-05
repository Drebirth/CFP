using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CFP.Models
{
    public class RegisterViewModel
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
