using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MagicPonySparkleLand.Models
{
    public class RoleEditViewModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<NewUser> Members { get; set; }
        public IEnumerable<NewUser> NonMembers { get; set; }
    }
}
