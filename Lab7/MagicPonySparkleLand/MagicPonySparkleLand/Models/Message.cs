using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MagicPonySparkleLand.Models
{
    public class Message
    {
        private List<User> users = new List<User>();
        public List<User> Users { get { return users; } }

        public int MessageID { get; set; } //Primary Key
        public string MessageText { get; set; }
        public string Subject { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
}
