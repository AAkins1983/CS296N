using System;

namespace MagicPonySparkleLand.Models
{
    public class Message : User
    {
        public int MessageID { get; set; }
        public string MessageText { get; set; }
        public DateTime Date { get; set; }
    }
}
