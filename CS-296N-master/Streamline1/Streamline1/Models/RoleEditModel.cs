using Microsoft.AspNetCore.Identity;
using Streamline1.Infrastructure;
using System.Collections.Generic;

namespace Streamline1.Models
{
    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
}
