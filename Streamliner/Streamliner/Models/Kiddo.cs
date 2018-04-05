using System.Collections.Generic;

namespace Streamliner.Models
{
    public class Kiddo
    {
        public int KiddoID { get; set; } //PK
        public int TaskItemID { get; set; } //FK

        private List<TaskItem> tasks = new List<TaskItem>();
        public List<TaskItem> TaskItems { get { return tasks; } }

        public string Name { get; set; }
    }
}
