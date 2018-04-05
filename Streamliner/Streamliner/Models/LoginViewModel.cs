using System.ComponentModel.DataAnnotations;

namespace Streamliner.Models
{
    public class LoginViewModel
    {
        [Required]
        [UIHint("username")]
        public string Username { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
