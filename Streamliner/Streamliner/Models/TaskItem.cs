using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Streamliner.Models
{
    public class TaskItem
    {
        public int TaskItemID { get; set; } //PK
        //public int KiddoID { get; set; } //FK

        //private List<Kiddo> kiddos = new List<Kiddo>();
        //public List<Kiddo> Kiddos { get { return kiddos; } }

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }
    }
}
