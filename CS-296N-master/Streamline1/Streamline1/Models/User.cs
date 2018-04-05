using Microsoft.AspNetCore.Identity;

namespace Streamline1.Models
{
    public class User : IdentityUser
    {
        public string Username { get; set; }
    }
}