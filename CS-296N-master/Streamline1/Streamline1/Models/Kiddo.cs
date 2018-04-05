using System.Collections.Generic;

namespace Streamline1.Models
{
    public class Kiddo
    {
        public int KiddoID { get; set; } //PK

        public string Name { get; set; }

        private List<TaskItem> taskItems = new List<TaskItem>();
        public List<TaskItem> TaskItems { get { return taskItems; } }
    }
}
