using System.Collections.Generic;

namespace ToDoApi.Models
{
    public class TaskBoard
    {
        public int TaskBoardId { get; set; }
        public string Name { get; set; }
        public virtual List<Task> Tasks { get; set; }
    }
}
