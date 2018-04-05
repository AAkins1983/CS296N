using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MPSL.Models
{
    public class Message
    {
        private List<MessUser> musers = new List<MessUser>();
        public List<MessUser> MessUsers { get { return musers; } }

        public int MessageID { get; set; } //PK

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public string MessageText { get; set; }
        public string Subject { get; set; }
    }
}
