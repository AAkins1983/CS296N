namespace Streamline1.Models
{
    public class TaskItem
    {
        public int TaskItemID { get; set; } //PK
        public int KiddoID { get; set; } //FK
        
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
