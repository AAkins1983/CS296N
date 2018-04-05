using Microsoft.AspNetCore.Identity;

namespace MagicPonySparkleLand.Models
{
    public class NewUser : IdentityUser
    {
        //public int NewUserID { get; set; }

        //public User ExistingUser { get; set; }

        //public User Member { get; set; }

        // These properties are in addition to those inherited from IdentityUser
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
