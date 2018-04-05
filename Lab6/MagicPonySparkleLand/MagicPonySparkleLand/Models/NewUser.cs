using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPonySparkleLand.Models
{
    public class NewUser : IdentityUser
    {
        public int NewUserID { get; set; }

        public User ExistingUser { get; set; }

        // These properties are in addition to those inherited from IdentityUser
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
