using System.Collections.Generic;

namespace MagicPonySparkleLand.Models
{
    public class User 
    {
        public int UserID { get; set; } //Primary Key
        public int MessageID { get; set; } //Foreign Key

        public string Name { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            User userObj = obj as User;
            if (userObj == null)
                return false;
            else
                return Name == userObj.Name && Email == userObj.Email;
        }

        public override int GetHashCode()
        {
            var hashCode = -1696464566;
            hashCode = hashCode * -1521134295 + UserID.GetHashCode();
            hashCode = hashCode * -1521134295 + MessageID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Email.GetHashCode();
            return hashCode;
        }
    }
}
