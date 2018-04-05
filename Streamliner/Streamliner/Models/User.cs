using Microsoft.AspNetCore.Identity;

namespace Streamliner.Models
{
    public class User : IdentityUser
    {
        //These properties are in addition to those inherited from IdentityUser
        public string Name { get; set; }
        public string AccountType { get; set; }
        public string Password { get; set; }
    }
}