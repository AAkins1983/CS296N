namespace Streamline.Models
{
    public class TaskItem
    {
        public int TaskItemID { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        //public override bool Equals(object obj)
        //{
        //    TaskItem taskObj = obj as TaskItem;
        //    if (taskObj == null)
        //        return false;
        //    else
        //        return Description == taskObj.Description && Category == taskObj.Category;
        //}
    }
}
