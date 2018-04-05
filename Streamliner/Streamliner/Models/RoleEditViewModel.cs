using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Streamliner.Models
{
    public class RoleEditViewModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
}
