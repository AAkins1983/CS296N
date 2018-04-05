using System.Collections.Generic;

namespace Streamline.Models
{
    public class Kiddo
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        public List<TaskItem> Tasks { get { return tasks; } }

        public int KiddoID { get; set; }
        public int TaskItemID { get; set; }
        public string Name { get; set; }
    }
}
