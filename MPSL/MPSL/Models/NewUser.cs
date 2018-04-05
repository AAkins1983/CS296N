using Microsoft.AspNetCore.Identity;

namespace MPSL.Models
{
    public class NewUser : IdentityUser
    {
        //public int Id { get; set; } //PK
        //public int MessageID { get; set; } //FK
        
        // These properties are in addition to those inherited from IdentityUser
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
