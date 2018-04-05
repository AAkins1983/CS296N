namespace MagicPonySparkleLand.Models
{
    public class User 
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        //public override bool Equals(object obj)
        //{
        //    User userObj = obj as User;
        //    if (userObj == null)
        //        return false;
        //    else
        //        return Name == userObj.Name && Email == userObj.Email;
        //}
    }
}
