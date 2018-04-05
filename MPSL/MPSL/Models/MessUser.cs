namespace MPSL.Models
{
    public class MessUser
    {
        public int MessUserID { get; set; }   // PK
        public int MessageID { get; set; }     // FK
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
